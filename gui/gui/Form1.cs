using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace gui
{
    public partial class Form1 : Form
    {
        private AppBoard appBoard;
        private EventHandler ev;
        private double integral = 0;
        public Form1()
        {
            appBoard = new AppBoard();
            InitializeComponent();
            loadForm();
            setupCombos();
        }
                // INITIALISATION //
       public void loadForm()
        {
            try
            {
                string[] comPorts = appBoard.getCOMs(); // Get the list of COM ports
                serialPortStatusLED.On = false;// connection light off
                
                comPortDropdown.Items.Clear(); // clear any existing items in the ComboBox

                // Add each COM port to the ComboBox
                foreach (string port in comPorts)
                {
                    comPortDropdown.Items.Add(port);
                }
                lampIntensityScroll.Value = 0;
                lampPercentDisplay.Text = "0%";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateTimerEvent(EventHandler newev)
        {
            appTimer.Stop();
            if (ev != null)
                appTimer.Tick -= ev;
            appTimer.Tick += newev;
            ev = newev;
            appTimer.Start();
        }

        private void appTabs_SelectedIndexChanged(object sender, EventArgs e) // TAB CONTROL
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: // Setup Tab
                    appTimer.Stop();
                    break;

                case 1: // Digital I/O Tab
                    UpdateTimerEvent(digIO_Tick);
                    break;

                case 2: // Pot Tab
                    UpdateTimerEvent(pot_tick);
                    break;

                case 3: // Temp Tab
                    //UpdateTimerEvent(temp_tick);
                    break;
            }
        }
        private void lampIntensityScroll_Scroll(object sender, ScrollEventArgs e)
        {
            lampPercentDisplay.Text = ((100*lampIntensityScroll.Value)/255).ToString() + "%";
        }

        // SETUP PAGE //

        private void setupCombos() // sets default baud rate to 38400
        {
            baudRateDropdown.SelectedIndex = 2;
        }
        
        private void connectButton_Click(object sender, EventArgs e) //connection button
        {
            try
            {
                //Backend: connect
                int baudint = 0; //initialise baud rate
                Int32.TryParse(baudRateDropdown.Text, out baudint); //convert baudrate string from dropdown to int
                appBoard.Connect(comPortDropdown.Text, baudint); //pass baud rate and comport to appboard function connecting

                //UI: turn on disconnect button and turn off connect button, light connected LED
                disconnectButton.Enabled = true; 
                connectButton.Enabled = false;
                serialPortStatusLED.On = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Connecting: {ex.Message}");
            }
        }         

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            appBoard.Disconnect(); // Use AppBoard to disconnect
            //turn stuff on/off accordingly
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            serialPortStatusLED.Enabled = false;
            serialPortStatusLED.On = false;
        }

                // DIGI IO PAGE //

        public byte getPORTCValue()
        {
            byte lsb = 0x00;//initialise least significant byte to send

            //check which boxes are ticked and assign accordingly
            if (tickPC0.Checked) lsb |= 0b00000001;
            if (tickPC1.Checked) lsb |= 0b00000010;
            if (tickPC2.Checked) lsb |= 0b00000100;
            if (tickPC3.Checked) lsb |= 0b00001000;
            if (tickPC4.Checked) lsb |= 0b00010000;
            if (tickPC5.Checked) lsb |= 0b00100000;
            if (tickPC6.Checked) lsb |= 0b01000000;
            if (tickPC7.Checked) lsb |= 0b10000000;

            return lsb; //return lsb
        }

        public void setPINALEDs(byte PINAVal)
        {
            //set leds according to switches flipped on board 
            pa0LED.Color = (PINAVal & (1 << 0)) != 0 ? Color.Red : Color.Black;
            pa1LED.Color = (PINAVal & (1 << 1)) != 0 ? Color.Red : Color.Black;
            pa2LED.Color = (PINAVal & (1 << 2)) != 0 ? Color.Red : Color.Black;
            pa3LED.Color = (PINAVal & (1 << 3)) != 0 ? Color.Red : Color.Black;
            pa4LED.Color = (PINAVal & (1 << 4)) != 0 ? Color.Red : Color.Black;
            pa5LED.Color = (PINAVal & (1 << 5)) != 0 ? Color.Red : Color.Black;
            pa6LED.Color = (PINAVal & (1 << 6)) != 0 ? Color.Red : Color.Black;
            pa7LED.Color = (PINAVal & (1 << 7)) != 0 ? Color.Red : Color.Black;
        }

        public void displayByteInHex(byte value)
        {
            // split the byte into two 4-bit nibbles
            byte highNibble = (byte)(value >> 4);  // most significant nibble
            byte lowNibble = (byte)(value & 0x0F); // Least significant nibble

            // convert each nibble to hex
            char highChar = hexToChar(highNibble);
            char lowChar = hexToChar(lowNibble);

            // sevenSegment to display the hex digits
            sevenSegment1.Value = highChar.ToString();
            sevenSegment2.Value = lowChar.ToString();
        }

        private char hexToChar(byte nibble)
        {
            if (nibble >= 0 && nibble <= 9)
                return (char)('0' + nibble); // 0-9 are directly mapped
            else
                return (char)('A' + (nibble - 10)); // A-F for nibbles 10-15
        }

        void digIO_Tick(object sender, EventArgs e)
        {
            try
            {
                appBoard.WritePORTC(getPORTCValue());// button checks sent to board to display on portc
                byte PINAVal = appBoard.ReadPINA(); // get which switches are flipped
                setPINALEDs(PINAVal);//set appropriately
                displayByteInHex(PINAVal);//display on seven segment
            }
            
            catch (Exception ex)
            {
                tabControl1.SelectedIndex = 0;//boot back to setup page
                MessageBox.Show($"Error: {ex.Message}");
            } 

        }

                // POT TAB //

        void potentiometres()
        {
            float pot1DispVal = (5 * (float)appBoard.ReadPotV(0)) / 255;
            pot1VoltageDisplay.Value = pot1DispVal;
            float pot2DispVal = (5 * (float)appBoard.ReadPotV(1)) / 255;
            pot2VoltageDisplay.Value = pot2DispVal;
        }

        void lightsensor()
        {
            int lightDispVal = appBoard.ReadLight();
            lightDisplay.Value = lightDispVal;
        }

        void lampscroll()
        {
            byte[] value = BitConverter.GetBytes(lampIntensityScroll.Value);
            appBoard.WriteLamp(value);
        }

        void pot_tick(object sender, EventArgs e)
        {
            try
            {
                potentiometres();
                lampscroll();
                lightsensor();
            }
            catch (Exception ex)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

          /*      // TEMP TAB //

        void pi_Logic(double desiredTemp, int kp, int ki)
        {
            // Read the current temp
            double currentTemp = appBoard.ReadTemp();

            // Calculate the error
            double error = (currentTemp - desiredTemp);

            // Proportional term (P)
            double proportional = kp * error;

            // Integral term (I), integrating the error over time
            integral += error; 
            double integralTerm = ki * integral;

            // Total output (P + I)
            double output = proportional + integralTerm;

            if (error < 0) // Desired temperature is higher, use the heater
            {
                // Map the output to the heater's PWM range 
                byte[] heaterValue = { (byte)((byte)output & 0xFF), (byte)(((byte)output >> 8) & 0xFF) };
                appBoard.WriteHeat(heaterValue); // Send PWM value to the heater
            }
            else if (error > 0) // Desired temperature is lower, use the fan
            {
                // Map the output to the fan's PWM range 
                byte[] fanValue = { (byte)((byte)output & 0xFF), (byte)(((byte)output >> 8) & 0xFF) };
                appBoard.WriteFan(fanValue); // Send PWM value to the fan
            }

        }

        void temp_tick(object sender, EventArgs e)
        {
            double desiredTemp = (double)setDesiredTemp.Value;
            int kp = (int)setKP.Value;
            int ki = (int)setKI.Value;
            

            pi_Logic(desiredTemp, kp, ki);

        }
          */
    }
}



