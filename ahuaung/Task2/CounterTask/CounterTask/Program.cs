// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace CounterTask;

public class Program
{
    // PrintCounters method
    private static void PrintCounters(Counter[] counters)
    {
        foreach (Counter c in counters)
        {
            Console.WriteLine($"{c.Name} is {c.Ticks}");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Create an array of 3 counters
        Counter[] myCounters = new Counter[3];
        
        // Initialize counters with names
        myCounters[0] = new Counter("Counter 1");
        myCounters[1] = new Counter("Counter 2");
        myCounters[2] = myCounters[0];
        
        // Print initial state
        Console.WriteLine("Initial state:");
        PrintCounters(myCounters);
        
        // Increment counters different numbers of times
        for (int i = 1; i <= 9; i++)
            myCounters[0].Increment();   
        for (int i = 1; i <= 14; i++)
            myCounters[1].Increment();
        
        // Print after increments
        Console.WriteLine("After increments:");
        PrintCounters(myCounters);
        
        // Reset the second counter
        myCounters[2].Reset();
        
        // Print after reset
        Console.WriteLine("After reset:");
        PrintCounters(myCounters);

        //
        Console.WriteLine("Testing IncrementByFive:");
        myCounters[0].IncrementByFive();
        myCounters[1].IncrementByFive();
        myCounters[2].IncrementByFive();
        PrintCounters(myCounters);
        //will result Counter 1 is 10 because myCounters[2] = myCounters[0]

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}