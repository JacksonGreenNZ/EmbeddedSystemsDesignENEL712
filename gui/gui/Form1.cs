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

//if(tabControl1.SelectedTab == setupPage)

namespace gui
{
    public partial class Form1 : Form
    {
        private AppBoard appBoard;
        private EventHandler ev;
        public Form1()
        {
            InitializeComponent();
            setupCombos();
        }

        private void setupCombos()
        {
            baudRateDropdown.SelectedIndex = 2;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                int baudint = 0;
                Int32.TryParse(baudRateDropdown.Text, out baudint);
                appBoard.Connect(comPortDropdown.Text, baudint); // Use AppBoard to connect
                disconnectButton.Enabled = true;
                connectButton.Enabled = false;
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

        void digIO_Tick(object sender, EventArgs e)
        {
            appBoard.ReadPINA(); // Delegate hardware interaction to AppBoard
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

    }

}



