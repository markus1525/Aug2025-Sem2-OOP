/**
 * Discussion Week 3 (Class and Object) - Group Solution
 * Group Members: [Add your group members' names here]
 * 
 * Object Chosen: Car
 */

using System;
using System.Collections.Generic;

// 1) Object Analysis:
// What the Car object should KNOW (Properties):
// - Brand/Make
// - Model
// - Year
// - Color
// - Engine size
// - Current speed
// - Fuel level
// - Is engine running?

// What the Car object can DO (Methods):
// - Start engine
// - Stop engine
// - Accelerate
// - Brake
// - Refuel
// - Display car information
// - Honk horn

// 2) Class Declaration and Implementation:
public class Car
{
    // Private fields (what the object knows)
    private string brand;
    private string model;
    private int year;
    private string color;
    private double engineSize;
    private int currentSpeed;
    private double fuelLevel;
    private bool isEngineRunning;

    // Constructor
    public Car(string brand, string model, int year, string color, double engineSize)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
        this.color = color;
        this.engineSize = engineSize;
        this.currentSpeed = 0;
        this.fuelLevel = 50.0; // Start with half tank
        this.isEngineRunning = false;
    }

    // Properties (C# way of getter/setter methods)
    public string Brand
    {
        get { return brand; }
    }

    public string Model
    {
        get { return model; }
    }

    public int Year
    {
        get { return year; }
    }

    public string Color
    {
        get { return color; }
    }

    public double EngineSize
    {
        get { return engineSize; }
    }

    public int CurrentSpeed
    {
        get { return currentSpeed; }
    }

    public double FuelLevel
    {
        get { return fuelLevel; }
    }

    public bool IsEngineRunning
    {
        get { return isEngineRunning; }
    }

    // Methods (what the object can do)
    public void StartEngine()
    {
        if (!isEngineRunning && fuelLevel > 0)
        {
            isEngineRunning = true;
            Console.WriteLine($"{brand} {model} engine started! Vroom!");
        }
        else if (fuelLevel <= 0)
        {
            Console.WriteLine("Cannot start engine - no fuel!");
        }
        else
        {
            Console.WriteLine("Engine is already running!");
        }
    }

    public void StopEngine()
    {
        if (isEngineRunning)
        {
            isEngineRunning = false;
            currentSpeed = 0;
            Console.WriteLine($"{brand} {model} engine stopped.");
        }
        else
        {
            Console.WriteLine("Engine is already off!");
        }
    }

    public void Accelerate(int speedIncrease)
    {
        if (isEngineRunning && fuelLevel > 0)
        {
            currentSpeed += speedIncrease;
            if (currentSpeed > 200) // Speed limit
            {
                currentSpeed = 200;
            }
            // Use some fuel when accelerating
            fuelLevel -= speedIncrease * 0.1;
            if (fuelLevel < 0)
            {
                fuelLevel = 0;
            }
            Console.WriteLine($"{brand} {model} accelerated! Current speed: {currentSpeed} km/h");

            if (fuelLevel <= 0)
            {
                StopEngine();
                Console.WriteLine("Out of fuel! Engine stopped.");
            }
        }
        else if (!isEngineRunning)
        {
            Console.WriteLine("Cannot accelerate - engine is not running!");
        }
        else
        {
            Console.WriteLine("Cannot accelerate - out of fuel!");
        }
    }

    public void Brake(int speedDecrease)
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= speedDecrease;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
            Console.WriteLine($"{brand} {model} braked! Current speed: {currentSpeed} km/h");
        }
        else
        {
            Console.WriteLine("Car is already stopped!");
        }
    }

    public void Refuel(double amount)
    {
        if (amount > 0)
        {
            fuelLevel += amount;
            if (fuelLevel > 100.0)
            {
                fuelLevel = 100.0; // Full tank
            }
            Console.WriteLine($"Refueled {brand} {model}. Fuel level: {fuelLevel:F1}%");
        }
        else
        {
            Console.WriteLine("Invalid fuel amount!");
        }
    }

    public void HonkHorn()
    {
        Console.WriteLine($"{brand} {model} says: BEEP BEEP!");
    }

    public void DisplayInfo()
    {
        Console.WriteLine("=== Car Information ===");
        Console.WriteLine($"Brand: {brand}");
        Console.WriteLine($"Model: {model}");
        Console.WriteLine($"Year: {year}");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Engine Size: {engineSize}L");
        Console.WriteLine($"Current Speed: {currentSpeed} km/h");
        Console.WriteLine($"Fuel Level: {fuelLevel:F1}%");
        Console.WriteLine($"Engine Running: {(isEngineRunning ? "Yes" : "No")}");
        Console.WriteLine();
    }

    // Override ToString method
    public override string ToString()
    {
        return $"{year} {color} {brand} {model} (Speed: {currentSpeed} km/h, Fuel: {fuelLevel:F1}%)";
    }
}

// 3) Main Function with List of Objects:
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Creating List of Car Objects ===\n");

        // Create a list to store Car objects
        List<Car> carList = new List<Car>();

        // Create multiple Car objects and add them to the list
        carList.Add(new Car("Toyota", "Camry", 2022, "White", 2.5));
        carList.Add(new Car("Honda", "Civic", 2021, "Blue", 1.8));
        carList.Add(new Car("BMW", "X3", 2023, "Black", 3.0));
        carList.Add(new Car("Ford", "Mustang", 2020, "Red", 5.0));
        carList.Add(new Car("Mercedes", "C-Class", 2022, "Silver", 2.0));

        // Display all cars in the list
        Console.WriteLine($"Total cars created: {carList.Count}\n");

        // Display information of all cars
        for (int i = 0; i < carList.Count; i++)
        {
            Console.WriteLine($"Car {i + 1}:");
            carList[i].DisplayInfo();
        }

        // Demonstrate object methods
        Console.WriteLine("=== Demonstrating Car Methods ===\n");

        // Get the first car (Toyota Camry)
        Car toyota = carList[0];

        // Start the engine and drive
        toyota.StartEngine();
        toyota.HonkHorn();
        toyota.Accelerate(50);
        toyota.Accelerate(30);
        toyota.Brake(20);
        toyota.DisplayInfo();

        // Get the second car (Honda Civic)
        Car honda = carList[1];
        honda.StartEngine();
        honda.Accelerate(80);
        honda.Refuel(25.0);
        honda.DisplayInfo();

        // Race scenario - make all cars go fast!
        Console.WriteLine("=== Car Race Simulation ===");
        foreach (Car car in carList)
        {
            car.StartEngine();
            car.Accelerate(100);
            car.HonkHorn();
        }

        // Stop all engines
        Console.WriteLine("\n=== Race Finished - Stopping All Cars ===");
        foreach (Car car in carList)
        {
            car.Brake(car.CurrentSpeed); // Brake to full stop
            car.StopEngine();
        }

        // Final status using ToString()
        Console.WriteLine("\n=== Final Car Status ===");
        for (int i = 0; i < carList.Count; i++)
        {
            Console.WriteLine($"Car {i + 1}: {carList[i].ToString()}");
        }

        // Refuel all cars for next use
        Console.WriteLine("\n=== Refueling All Cars ===");
        foreach (Car car in carList)
        {
            car.Refuel(50.0);
        }

        // Keep console open
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}