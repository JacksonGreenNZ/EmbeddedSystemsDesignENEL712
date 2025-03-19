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

        private static readonly object serialLock = new object();

        public byte ReadPINA()
        {
            lock (serialLock)
            {
                byte[] ReadPINA = { startByte, 0x01, stopByte };
                serialPort.Write(ReadPINA, 0, ReadPINA.Length);
                int response = serialPort.ReadByte();
                return (byte)response;
            }
        }

        public void WritePORTC(byte lsb)
        {
            lock (serialLock)
            {
                byte chaff = 0xff;
                byte[] WritePORTC = { startByte, 0xA, lsb, chaff, stopByte };
                serialPort.Write(WritePORTC, 0, WritePORTC.Length);
            }
        }
    }
}
