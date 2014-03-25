using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.IO.Ports;

namespace NetduinoApplication1
{
    public class Program
    {

        private static string message = @"LED"; 

        public static void Main()
        {
            // Instantiate the communications
            // port with some basic settings
            SerialPort port = new SerialPort(
              "COM1", 9600, Parity.None, 8, StopBits.One);

            // Open the port for communications
            port.Open();
            OutputPort ledPort = new OutputPort(Pins.ONBOARD_LED, false);
            byte[] buffer = new byte[message.Length];
            buffer = System.Text.Encoding.UTF8.GetBytes(message);
            try
            {
                while (true)
                {
                    ledPort.Write(true);
                    Thread.Sleep(200);
                    port.Write(buffer, 0, buffer.Length);
                    ledPort.Write(false);
                    Thread.Sleep(5000);
                }

            }
            finally
            {
                port.Close();
            }
        }

    }
}
