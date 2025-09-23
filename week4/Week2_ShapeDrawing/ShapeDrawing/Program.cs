// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace ShapeDrawing;

public class Program
{
    public static void Main(string[] args)
    {
        //Declare a shape object
        Shape myShape;
        Shape mySecShape;  //VERIFICATION TASK

        //Create a new shape object
        myShape = new Shape(181);
        mySecShape = new Shape(100);  //VERIFICATION TASK

        //Draw the shape
        Console.WriteLine("myShape");
        myShape.Draw();

        //VERIFICATION TASK
        Console.WriteLine("mySecShape (VERIFICATION TASK)");
        mySecShape.Draw();  //VERIFICATION TASK

        //Check if the shape is at the position (10,10)
        Console.WriteLine($"Is the shape at (10,10)? {myShape.IsAt(10, 10)}");
        Console.WriteLine($"Is the shape at (190,190)? {myShape.IsAt(190, 190)}");

    }
}