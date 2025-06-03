using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;


namespace gui
{
    internal class AppBoard
    {
        public SerialPort serialPort;
        byte startByte = 0x53;
        byte stopByte = 0xAA;

        public AppBoard()
        {
            serialPort = new SerialPort();
        }

        public string[] getCOMs()
        {
            return SerialPort.GetPortNames();
        }

        public void Connect(string portName, int baudRate, Action onConnected)
        {
            // Create a background thread to open the serial port to stop jumping to next task before connection is made
            ThreadPool.QueueUserWorkItem(state =>
            {
                try
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.Open();  // Try to open the port
                    int timeoutMs = 3000; // Wait up to 3 seconds
                    int intervalMs = 100;
                    int waited = 0;

                    while (!serialPort.IsOpen && waited < timeoutMs)
                    {
                        Thread.Sleep(intervalMs);
                        waited += intervalMs;
                    }

                    if (serialPort.IsOpen)
                    {
                        onConnected?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to open {portName} within timeout.", "Connection Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Disconnect();
                    MessageBox.Show($"Error opening {portName}: {ex.Message}", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Disconnect();
                    MessageBox.Show($"Error opening {portName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        
        public void Disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public int checkTx()
        {
            byte[] checkConnect = { startByte, 0x00, stopByte };
            try
            {
                serialPort.Write(checkConnect, 0, checkConnect.Length);
                serialPort.ReadTimeout = 1000; // 1 second timeout
                return serialPort.ReadByte();
            }
            catch (TimeoutException)
            {
                Disconnect();
                return -1;
            }
            catch(Exception)
            {
                Disconnect() ; 
                return -2;
            }
        }

        public byte ReadPINA()
        {
                byte[] ReadPINA = { startByte, 0x01, stopByte };
                serialPort.Write(ReadPINA, 0, ReadPINA.Length);
                int response = serialPort.ReadByte();
                return (byte)response;
        }

        public void WritePORTC(byte lsb)
        {
                byte chaff = 0xff;
                byte[] WritePORTC = { startByte, 0x0A, lsb, chaff, stopByte };
                serialPort.Write(WritePORTC, 0, WritePORTC.Length);
                int response = serialPort.ReadByte();
        }

        public double ReadPotV(int pot)
        {
            byte[] readPOT = null;
            switch (pot)
            {
                case 0: 
                    readPOT = new byte[] { startByte, 0x02, stopByte };
                    break;
                case 1:
                    readPOT = new byte[] { startByte, 0x03, stopByte };
                    break;
            }
            
            
            serialPort.Write(readPOT,0,readPOT.Length);
            int response = serialPort.ReadByte();
   
            return (double)response;
        }

        public int ReadLight()
        {
            byte[] readLight = { startByte, 0x05, stopByte };
            serialPort.Write(readLight, 0, readLight.Length);
            return serialPort.ReadByte();
        }

        public void WriteLamp(byte[] value)
        {
            byte lsb = value[0];
            byte msb = value[1];
            byte[] WriteLamp = { startByte, 0x0C, lsb, msb, stopByte };
            serialPort.Write(WriteLamp, 0, WriteLamp.Length);
            int response = serialPort.ReadByte();
        }

        public void tempTabClosed()
        {
            //turn off temp/fan stuff
            byte[] pwmBytesOff = { (byte)(0 & 0xFF), (byte)((0 >> 8) & 0xFF) };
            WriteHeat("off");
            WriteFan(pwmBytesOff);
        }

        public double ReadTemp()
        {
            byte[] readTemp = { startByte, 0x04, stopByte };
            serialPort.Write(readTemp, 0, readTemp.Length);
            return (double)serialPort.ReadByte();
        }
        public void WriteFan(byte[] value)
        {
            byte lsb = value[0];
            byte msb = value[1];
            byte[] Writefan = { startByte, 0x0D, lsb, msb, stopByte};
            serialPort.Write(Writefan, 0, Writefan.Length);
            int response = serialPort.ReadByte();
            if (response != 0x0D)
            {
                MessageBox.Show("Wrong return (Fan)");
            }
        }

        public void WriteHeat(string value)
        {
            byte lsb = 0;
            byte msb = 0;
            if (value == "on")
            {
                lsb = 255;
                msb = 255;
            }
            byte[] Writeheat = { startByte, 0x0B, lsb, msb, stopByte };
            serialPort.Write(Writeheat, 0, Writeheat.Length);
            int response = serialPort.ReadByte();
            if(response!= 0x0B)
            {
                MessageBox.Show("Wrong return (Heat)");
            }
        }
    }
}
