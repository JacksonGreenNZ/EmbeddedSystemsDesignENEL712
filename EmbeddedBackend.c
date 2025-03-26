/*
 * EmbeddedBackend.c
 *
 * Created: 5/03/2025 12:49:56 pm
 * Author : qtr1230
 */ 

#define F_CPU 8000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

#define startConversion ADCSRA |= (1<<6) //initiates conversion
#define conversionRunning ADCSRA & (1<<6) //bit is cleared on conversion complete
#define tx_buffer_empty (UCSR1A & (1<<UDRE1)) //nothing in transmit buffer
//while (!tx_buffer_empty);//wait for transmitter to fill up

char *receiveByte;

//cases for isr
#define initialise 0
#define instruct 1
#define logLSB 2
#define logMSB 3
#define checkstop 6
unsigned char mode;
unsigned char readorwrite;
char startbyte = 0x53;
char stopbyte = 0xAA;  

//data information
unsigned char instruction;
unsigned char lsb = 0b00;
unsigned char msb = 0b00;
int sixteenbit;

//define channels
#define p02 0b01100001
#define p01 0b01100010
#define thermometre 0b01100011
#define lightsensor 0b01100000


//enable reading inputs from selected channel and outputs completed conversion
char readADC(char channel)
{
	ADMUX = channel;
	startConversion;
	
	while(conversionRunning);

	return(ADCH);//change this to send over usart, currently returning so testable
}

/////////READ FUNCTIONS BEGIN //////////
void txCheck(){
	UDR1 = 0x0F;
}

void readPINA(){
	UDR1=PINA;
}

void readPOT1(){
	UDR1 = readADC(p01);
}

void readPOT2(){
	UDR1 = readADC(p02);
}

void readTemp(){
	UDR1 = readADC(thermometre);
}

void readLight(){
	UDR1 = readADC(lightsensor);
}


/////////WRITE FUNCTIONS BEGIN //////////
void setPORTC(unsigned char lsb){
	//write the 8 LSB to PORTC, return 0x0A over udr1
	PORTC = lsb;
	UDR1 = 0x0A;
}

void setHeater(int sixteenbit){
	OCR1C = sixteenbit;
	UDR1 = 0x0B;
}

void setLight(int sixteenbit){
	OCR1B = sixteenbit;
	UDR1 = 0x0C;
}

void setMotor(int sixteenbit){
	OCR1A = sixteenbit;
	UDR1 = 0x0D;
}

/////////READ/WRITE FUNCTIONS END //////////


void write(unsigned char instruction, unsigned char lsb, int sixteenbit){ //write functions
	switch(instruction){
		case 0x0A:
			setPORTC(lsb);
			break;
		case 0x0B:
			setHeater(sixteenbit);
			break;	
		case 0x0C:
			setLight(sixteenbit);
			break;	
		case 0x0D:
			setMotor(sixteenbit);
			break;
	}
}

void read(unsigned instruction){//read functions
		switch(instruction){
			case 0x00:
				txCheck();
				break;
			case 0x01:
				readPINA();
				break;
			case 0x02:
				readPOT1();
				break;
			case 0x03:
				readPOT2();
				break;
			case 0x04:
				readTemp();
				break;
			case 0x05:
				readLight();
				break;
		}
}

////////INTERRUPT///////////

ISR(USART1_RX_vect){ //receive interrupt
	
	*receiveByte = UDR1;//pointer to current byte
	
	switch(mode){
	
		case initialise:
			//reset variables
			instruction = 0;
			readorwrite = 2;
			lsb = 0;
			msb = 0; 
			
			if(*receiveByte == startbyte){ //if the received byte is 0x53
				mode =  instruct; //standby for instruction byte
			} 
		break;
	
		case instruct:
			instruction = *receiveByte; //save as instruction
			if(*receiveByte<0x0A){ //if received byte is read instruction
				
				readorwrite = 0; //select the right function
				mode = checkstop; //check if stop byte received
			}
			
			else{
				mode = logLSB; //otherwise jump to logging least significant bit for writing
			}
			
			break;
		
		case logLSB:// log lsb
			lsb = *receiveByte;
			mode = logMSB;
			break;
	
		case logMSB://log msb and check stop byte received
			msb = *receiveByte;
			sixteenbit = (msb<<8)|lsb;
			readorwrite = 1;
			mode = checkstop;
			break;
		
		case checkstop:
			if(*receiveByte == stopbyte){// if the stop byte is received continue
				switch(readorwrite){
				case 0:
					read(instruction);//pass instruction to function
					mode = initialise;//return to waiting state
					break;
				
				case 1:
					write(instruction, lsb, sixteenbit);//pass instruction, lsb and msb to function
					mode = initialise;//return to waiting state	
					break;	
				
				default://error handling
					mode = initialise;
					break;
				}
			}
			
			else{//if no stop byte received, reset
				mode = initialise;
			}	
			break;
	}		
}

///////////SETUP///////////

void setup(){
	DDRC = 0xFF;//all leds as output
	DDRB = 0b11100000;//fan/lamp/heater as output
	
	//start off
	PORTC = 0x00;
	PORTB = 0x00;

	//Setup board to use switches
	DDRE = 3;
	PORTE = 0b00000000;
	DDRA = 0;
	//conversion
	ADCSRA = 0b10000111;
	
	//TCCR1A = 0b10100101;
	//TCCR1B = 0b00000001;
	
	//toms tcc setup
	TCCR1A = 0b10101010;
	TCCR1B = 0b00011001;
	ICR1 = 399;
	
	cli();
	sei();
	
	UCSR1B = 0b10011000; //usart tx/rx on, enable recieve complete interrupt 
	UCSR1C = 0b00000110;//async no parity bit, 1 stop bit, 8 bit char size
	UBRR1L = 12; //38400 buad
	
	//start with certain conditions
	mode = initialise;
	readorwrite = 2;
}

/////////MAIN/////////

int main(void)
{
	setup();
    while (1){}
}
