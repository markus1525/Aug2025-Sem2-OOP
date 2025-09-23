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

        //Create a new shape object
        myShape = new Shape(181);

        //Draw the shape
        myShape.Draw();

        //Check if the shape is at the position (10,10)
        Console.WriteLine($"Is the shape at (10,10)? {myShape.IsAt(10,10)}");

    }
}