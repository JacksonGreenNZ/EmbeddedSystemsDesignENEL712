using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gui
{
    internal class AppBoard
    {
        public SerialPort serialPort;
        byte startByte = 0x53;
        byte stopByte = 0xAA;
        private string comPort;

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
                    MessageBox.Show($"Error opening {portName}: {ex.Message}", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
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
            serialPort.Write(checkConnect, 0, checkConnect.Length);
            return serialPort.ReadByte();
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
            byte[] Writefan = { startByte, 0x0D, lsb, msb, stopByte };
            serialPort.Write(Writefan, 0, Writefan.Length);
            int response = serialPort.ReadByte();
        }

        public void WriteHeat(byte[] value)
        {
            byte lsb = value[0];
            byte msb = value[1];
            byte[] Writeheat = { startByte, 0x0B, lsb, msb, stopByte };
            serialPort.Write(Writeheat, 0, Writeheat.Length);
            int response = serialPort.ReadByte();
        }
    }
}
