using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gui
{
    internal class AppBoard
    {
        private SerialPort serialPort;

        public AppBoard(SerialPort port)
        {
            serialPort = port;
        }

        public void Connect(string portName, int baudRate)
        {
            try
            {
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to port: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public void ReadPINA()
        {
            byte[] ReadPINA = { 0x53, 0x01, 0xAA };
            serialPort.Write(ReadPINA, 0, ReadPINA.Length);
        }

        public void WritePORTC(byte msb, byte lsb)
        {
            byte[] WritePORTC = { 0x53, 0xA, msb, lsb, 0xAA };
            serialPort.Write(WritePORTC, 0, WritePORTC.Length);
        }
    }
}
