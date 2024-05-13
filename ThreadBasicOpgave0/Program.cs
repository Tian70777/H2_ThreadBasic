/* 
 * C# Program to Create a Simple Thread 
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
// Print the name of the current thread

class ThreadProgram
{
    public static void Main()
    {
        program pg = new program();

        // Create the first thread and set its name
        Thread thread1 = new Thread(new ThreadStart(pg.WorkThreadFunction));
        thread1.Name = "Thread 1";
        thread1.Start();

        // Create the second thread and set its name
        Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadFunction));
        thread2.Name = "Thread 2";
        thread2.Start();

        // Wait for user input to keep the console open
        Console.Read();
    }
}

class program
{
    public void WorkThreadFunction()
    {
        for (int i = 0; i < 5; i++)
        {
            // Print the name of the current thread
            Console.WriteLine($"Simple Thread: {Thread.CurrentThread.Name}");
        }
    }
}
