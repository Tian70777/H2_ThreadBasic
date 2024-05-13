using System;
using System.Threading;

public class Program
{
    static char toBePrinted = '*';

    public static void Main()
    {
        // Thread to Print 
        Thread printThread = new Thread(new ThreadStart(Print));
        printThread.Start();

        // Thread to Read user input
        Thread readThread = new Thread(new ThreadStart(Read));
        readThread.Start();
    }

    /// <summary>
    /// Method for print, start with print *
    /// until user press Enter
    /// static method, can be called from Main
    /// </summary>
    public static void Print()
    {
        while (true)
        {
            Console.Write(toBePrinted);
            Thread.Sleep(100);
        }
    }

    /// <summary>
    /// Method to read, waiting for a user input
    /// only update value of toBePrinted to the last char before user enter, and print it in the Print method
    /// if user press Enter without a new char, still print last updated char
    /// </summary>
    public static void Read()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                toBePrinted = input[^1];
            }
        }
    }

}