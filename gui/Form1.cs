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
using System.CodeDom;
using System.Windows.Forms.DataVisualization.Charting;

namespace gui
{
    public partial class Form1 : Form
    {
        private AppBoard appBoard;
        private EventHandler ev;
        private double integral;
        private int x;
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
                datBasStatLED.On = false;//6 weeks later my naming conventions are less verbose
                
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
                    appBoard.tempTabClosed();
                    break;

                case 1: // Digital I/O Tab
                    UpdateTimerEvent(digIO_Tick);
                    appBoard.tempTabClosed();
                    break;

                case 2: // Pot Tab
                    UpdateTimerEvent(pot_tick);
                    appBoard.tempTabClosed();
                    break;

                case 3: // Temp Tab
                    x = 0;
                    integral = 0;
                    UpdateTimerEvent(temp_tick);
                    break;
            }
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
                int baudint = 0;
                Int32.TryParse(baudRateDropdown.Text, out baudint);

                // Disable UI to avoid double-clicking while connecting
                connectButton.Enabled = false;

                // Trigger async connect with a callback
                appBoard.Connect(comPortDropdown.Text, baudint, () =>
                {
                    // Called from background thread, so invoke UI-safe changes
                    if (InvokeRequired)
                    {
                        Invoke(new Action(UIConnectResponse));
                    }
                    else
                    {
                        connectButton.Enabled = true;//turn back on if txcheck fails
                        UIConnectResponse();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Connecting: {ex.Message}");
            }
        }

        private void UIConnectResponse()
        {
            if(appBoard.checkTx()== 0x0F)
            {
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                connectButton.Enabled = false;
                serialPortStatusLED.On = true;
            }
            else
            {
                MessageBox.Show($"Error Connecting: Wrong byte recieved");
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
            pot2VoltageDisplay.RecommendedValue = pot2DispVal;
            pot1VoltageDisplay.RecommendedValue = pot1DispVal;
        }
        
        private void lampIntensityScroll_Scroll(object sender, ScrollEventArgs e)
        {
            lampPercentDisplay.Text = (-lampIntensityScroll.Value).ToString() + "%";
        }

        void lightSensor()
        {
            int lightDispVal = appBoard.ReadLight();
            lightDisplay.Value = lightDispVal;
            lightDisplay.RecommendedValue = lightDispVal;
        }

        void lampScroll()
        {
            byte[] value = BitConverter.GetBytes(-255*(lampIntensityScroll.Value)/100);
            appBoard.WriteLamp(value);
        }

        void pot_tick(object sender, EventArgs e)
        {
            try
            {
                potentiometres();
                lampScroll();
                lightSensor();
            }
            catch (Exception ex)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

                // TEMP TAB //

        double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        void piLogic(double desiredTemp, int kp, int ki)//NEED TO CHANGE THIS - HEAT SHOULD ALWAYS BE 100%, ONLY FAN ON PI
        {
            double currentTemp = appBoard.ReadTemp();

            //need to convert from bytes to actual degrees
            currentTemp = (currentTemp / 255)*5;
            currentTemp = currentTemp / 0.05;

            actualTempDisplay.Text = $"{currentTemp:F2} [C]";       

            tempChart.Series[0].Points.AddXY(x++, currentTemp);

            var yStripLine = new StripLine();//line to show desired temp
            yStripLine.Interval = 0;        
            yStripLine.StripWidth = 0;
            yStripLine.BackColor = Color.Red; 
            yStripLine.BorderWidth = 1;
            yStripLine.BorderColor = Color.Red;
            yStripLine.BorderDashStyle = ChartDashStyle.Dash;
            yStripLine.IntervalOffset = desiredTemp; 

            // Clear previous striplines if updating
            tempChart.ChartAreas[0].AxisY.StripLines.Clear();
            tempChart.ChartAreas[0].AxisY.StripLines.Add(yStripLine);

            // Find the max value between series and desiredTemp
            double maxSeriesValue = tempChart.Series[0].Points.Count > 0
                ? tempChart.Series[0].Points.Max(p => p.YValues[0])
                : 0;

            double yMax = Math.Max(maxSeriesValue, desiredTemp) + 5;
            tempChart.ChartAreas[0].AxisY.Maximum = yMax;

            double error = desiredTemp - currentTemp;

            if (Math.Abs(error) > 0.01)
            {
                double proportional = kp * error;
                integral += error;
                integral = Clamp(integral, -1000, 1000);  // Limiting the integral windup
                double integralTerm = ki * integral;
                double output = proportional + integralTerm;

                output = Math.Abs(output);
                output = Clamp(output, 0, 399);

                ushort pwmValue = (ushort)output;
                byte[] pwmBytes = { (byte)(pwmValue & 0xFF), (byte)((pwmValue >> 8) & 0xFF) };

                ushort pwmValueOff = 0;
                byte[] pwmBytesOff = { (byte)(pwmValueOff & 0xFF), (byte)((pwmValueOff >> 8) & 0xFF) };

                if (error > 0)
                {
                    appBoard.WriteHeat(pwmBytes);
                    appBoard.WriteFan(pwmBytesOff);
                    motorSpeedDisplay.Text = "0%";
                }
                else if (error < 0)
                {
                    double displayValue = (output / 399) * 100;
                    appBoard.WriteFan(pwmBytes);
                    appBoard.WriteHeat(pwmBytesOff);
                    motorSpeedDisplay.Text = $"{displayValue:F2}%";
                }
                else
                {
                    appBoard.WriteHeat(pwmBytesOff);
                    appBoard.WriteFan(pwmBytesOff);
                    motorSpeedDisplay.Text = "0%";
                }
            }
            else
            {
                appBoard.WriteHeat(new byte[] { 0, 0 });
                appBoard.WriteFan(new byte[] { 0, 0 });
            }
        }

        void temp_tick(object sender, EventArgs e)
        {
            double desiredTemp = (double)setpointTemp.Value;
            int kp = (int)kpTuning.Value;
            int ki = (int)kiTuning.Value;
            piLogic(desiredTemp, kp, ki);
        }
    }
}



