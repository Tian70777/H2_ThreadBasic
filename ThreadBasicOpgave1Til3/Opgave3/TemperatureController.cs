using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThreadBasicOpgave1Til3.Opgave3
{
    public class TemperatureController
    {
        private int alertCount = 0; // Counter for alerts
        private Thread? temperatureThread; // Thread to generate temperatures
        private List<int> temperatureList = new List<int>(); // List to store temperatures

        public Thread? TemperatureThread { get; set; } // Property to access temperatureThread

        public void ControllerStart()
        {
            temperatureThread = new Thread(() =>
            {
                // Generate temperatures until 3 alerts have been triggered
                // the thread will stop after 3 alerts
                while(alertCount < 3)
                {
                    int temperature = TemperatureGenerator.Generator();
                    temperatureList.Add(temperature); // Add temperature to list

                    // Check if temperature is below 0 or above 100
                    if (temperature < 0 || temperature > 100)
                    {
                        Console.WriteLine("Alert! \nTemperature is: " + temperature);
                        alertCount++;
                    }
                    else
                    {
                        Console.WriteLine("Temperature is: " + temperature);
                    }
                    Thread.Sleep(2000);
                }
            });

            // Set the TemperatureThread property to the temperatureThread
            TemperatureThread = temperatureThread;

            // Start the thread
            temperatureThread.Start();
        }

        // Method to access the list of temperatures
        public List<int> GetTemperatures()
        {
            return temperatureList;
        }
    }
}
