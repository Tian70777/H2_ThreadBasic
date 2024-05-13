using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using ThreadBasicOpgave1Til3.Opgave3;

class ThreadTest
{
    public static void Main()
    {
        // Create a new thread that will execute the WriteSth method with a parameter
        // use the `ParameterizedThreadStart` delegate instead of `ThreadStart`.
        Thread thread1 = new Thread(new ParameterizedThreadStart(WriteSth));
        thread1.Start("C#-trådning er nemt!");

        Thread thread2 = new Thread(new ParameterizedThreadStart(WriteSth));
        thread2.Start("Også med flere tråde…");

        // Start the asynchronous method
        WriteSthAsync("C#-trådning er nemt!");
        WriteSthAsync("Også med flere tråde…");


        //Opgave 3
        // Create a new instance of the TemperatureController class
        TemperatureController temperatureController = new TemperatureController();
        temperatureController.ControllerStart();

        // Check every 10 seconds if the temperature thread is still alive
        while (true)
        {
            Thread.Sleep(10000); // Sleep for 10 seconds
            if (!temperatureController.TemperatureThread.IsAlive)
            {
                Console.WriteLine("Alarm-tråd termineret!");
                break; // Exit the loop and terminate the main thread
            }
        }
        Console.WriteLine("All temperatures:");

        foreach(int temperature in temperatureController.GetTemperatures())
        {
            Console.WriteLine(temperature);
        }

        // Wait for user input to keep the console open
        Console.Read();
    }

    /// <summary>
    /// Use async method, then await Task.Delay(1000) to make the method non-blocking
    /// if use Thread.Sleep(1000) it will block the main thread
    /// </summary>
    /// <param name="message"></param>
    public static async void WriteSthAsync(string message)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(message);

            // Non-blocking delay
            await Task.Delay(1000);
        }
    }

    /// <summary>
    /// The `WriteSth` method is designed to take an `object` parameter 
    /// because it is intended to be used with the `ParameterizedThreadStart` delegate.
    /// 
    ///  `ParameterizedThreadStart` expects a method that takes a single `object` parameter.
    /// 
    /// </summary>
    /// <param name="message"></param>
    public static void WriteSth(object message)
    {
        // cast the object to a string
        string msg = (string)message;
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(msg);
        }
    }


}