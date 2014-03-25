using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            // initialize the sensor port, mine was registered as COM8, you may check yours
            // through the hardware devices from control panel
            SerialPort sensor = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            int bytesToRead = 0;
            string message;
            sensor.Open();
            try
            {
                while (true)
                {
                    // check if there are bytes incoming
                    bytesToRead = sensor.BytesToRead;
                    if (bytesToRead > 0)
                    {
                        byte[] input = new byte[bytesToRead];
                        // read the Xbee's input
                        sensor.Read(input, 0, bytesToRead);
                        // convert the bytes into string
                        message = System.Text.Encoding.UTF8.GetString(input);
                        Console.WriteLine(message);
                    }
                }

            }
            finally
            {
                // again always close the serial ports!
                sensor.Close();
            }
            
        }

        

    }
}
