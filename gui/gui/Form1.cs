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

//if(tabControl1.SelectedTab == setupPage)

namespace gui
{
    public partial class Form1 : Form
    {
        private AppBoard appBoard;
        private EventHandler ev;
        public Form1()
        {
            appBoard = new AppBoard();
            InitializeComponent();
            loadForm();
            setupCombos();
        }


       public void loadForm()
        {
            try
            {
                string[] comPorts = appBoard.getCOMs(); // Get the list of COM ports
                serialPortStatusLED.On = false;
                // Clear any existing items in the ComboBox
                comPortDropdown.Items.Clear();

                // Add each COM port to the ComboBox
                foreach (string port in comPorts)
                {
                    comPortDropdown.Items.Add(port);
                }
            }
            catch { Console.WriteLine("Error"); }



        }

        private void setupCombos()
        {
            baudRateDropdown.SelectedIndex = 2;
        }

        char connected = 'a';

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                int baudint = 0;
                Int32.TryParse(baudRateDropdown.Text, out baudint);
                appBoard.Connect(comPortDropdown.Text, baudint); // Use AppBoard to connect
                disconnectButton.Enabled = true;
                connectButton.Enabled = false;
                serialPortStatusLED.On = true;
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            appBoard.Disconnect(); // Use AppBoard to disconnect
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            serialPortStatusLED.Enabled = false;
            serialPortStatusLED.On = false;
        }

        private void appTabs_SelectedIndexChanged(object sender, EventArgs e)
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
                    break;

                case 3: // Temp Tab
                    break;
            }
        }

        public byte getPORTCValue()
        {
            byte lsb = 0x00;
            if (tickPC0.Checked) lsb |= 0b00000001;
            if (tickPC1.Checked) lsb |= 0b00000010;
            if (tickPC2.Checked) lsb |= 0b00000100;
            if (tickPC3.Checked) lsb |= 0b00001000;
            if (tickPC4.Checked) lsb |= 0b00010000;
            if (tickPC5.Checked) lsb |= 0b00100000;
            if (tickPC6.Checked) lsb |= 0b01000000;
            if (tickPC7.Checked) lsb |= 0b10000000;
            return lsb;
        }

        public void setPINALEDs(byte PINAVal)
        {
            pa0LED.Color = (PINAVal & (1 << 0)) != 0 ? Color.Red : Color.Black;
            pa1LED.Color = (PINAVal & (1 << 1)) != 0 ? Color.Red : Color.Black;
            pa2LED.Color = (PINAVal & (1 << 2)) != 0 ? Color.Red : Color.Black;
            pa3LED.Color = (PINAVal & (1 << 3)) != 0 ? Color.Red : Color.Black;
            pa4LED.Color = (PINAVal & (1 << 4)) != 0 ? Color.Red : Color.Black;
            pa5LED.Color = (PINAVal & (1 << 5)) != 0 ? Color.Red : Color.Black;
            pa6LED.Color = (PINAVal & (1 << 6)) != 0 ? Color.Red : Color.Black;
            pa7LED.Color = (PINAVal & (1 << 7)) != 0 ? Color.Red : Color.Black;
        }

        void digIO_Tick(object sender, EventArgs e)
        {
            try
            {   
                byte PINAVal = appBoard.ReadPINA();
                setPINALEDs(PINAVal);
                appBoard.WritePORTC(getPORTCValue());
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to port: {ex.Message}");
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



        private void lampIntensityScroll_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }

}



