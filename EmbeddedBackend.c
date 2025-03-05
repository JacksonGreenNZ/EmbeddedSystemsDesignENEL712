/*
 * EmbeddedBackend.c
 *
 * Created: 5/03/2025 12:49:56 pm
 * Author : qtr1230
 */ 


/*TO DO

1. adc conversion could probably send through tx after conversion instead of relying on read function - reduces repition
2. log lsb and msb for write function






*/

/*
isr(usart1_rx_vect) is the key interrupt, while(1) shouldn't contain much

0x53 starts contact
instruction pin (0x01-5 is read, A-D is write)
for write send MSB and LSB
stop bit 0xAA

Motor (OCR1A)
Lamp (OCR1B)
Heater (OCR1C)

interrupt come after every time receive data due to stop byte bullshit

ONLY DO BASIC LOGIC FOR INSTRUCTIONS ON C
LOGIC HANDLED BY C SHARP

*/

#define F_CPU 8000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

#define startConversion ADCSRA |= (1<<6) //initiates conversion
#define conversionRunning ADCSRA & (1<<6) //bit is cleared on conversion complete
#define tx_buffer_empty (UCSR1A & (1<<UDRE1)) //nothing in transmit buffer
//while (!tx_buffer_empty);//wait for transmitter to fill up USE LATER

char *receiveByte;

//cases for isr
#define initialise 0
#define instruct 1
#define logLSB 2
#define logMSB 3
unsigned char mode;
char startbyte = 0x53;  

unsigned char lsb;
unsigned char msb;

ISR(USART1_RX_vect){
	*receiveByte = UDR1;
	switch(mode){
		case initialise:
			if(*receiveByte == startbyte){
				mode =  instruct;
			} 
		break;
		case instruct:
			if(*receiveByte<0x0A){
				read()
				mode = initialise
				break;
			}
			write(*receiveByte);
			break;
		case logLSB:
			lsb = *receiveByte;
			mode = logMSB;
			break;
		case logMSB:
			msb = *receiveByte;
			mode 
			
	}	
	

}

char write(char writetype){
	//use this to work out which type of write is needed, 
}

char read(char instruction){
		switch(instruction){
			case 0x00:
				txCheck();
				break;
			case 0x01:
				readPINA();
			case 0x02:
				readPOT1()
			case 0x03:
				readPOT2()
			case 0x04:
				readTemp()
			case 0x05:
				readLight()
		}
}

char txCheck(){
	//send 0x0F over udr1;
}

char readPINA(){
	//send pina over udr1;
}

char readPOT1(){
	//adc conv channel 1
	//send adch over udr1;
}

char readPOT2(){
	//adc conv channel 0;
	//send adch over udr1;
}

char readTemp(){
	//adc conv channel 3?
	//send adch over udr1;
}

char readLight(){
	//adc conv channel 4?
	//send adch over udr1;
}


//enable reading inputs from selected channel and outputs completed conversion
char readADC(char channel)
{
	ADMUX = channel;
	startConversion;
	
	while(conversionRunning);

	return(ADCH);
}


void setup(){
	DDRC = 0xFF;//all leds as output
	DDRB |= (1<<DDB6);//lamp as output
	
	//start off
	PORTC = 0x00;
	PORTB = 0x00;

	//Setup board to use switches
	DDRE = 3;
	PORTE = 0b00000000;
	DDRA = 0;

	ADCSRA = 0b11100111;
	
	cli();
	sei();
	mode = initialise;
}

int main(void)
{
	setup()
    /* Replace with your application code */
    while (1) 
    {
    }
}

