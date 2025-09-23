using System;

namespace ShapeDrawing;

public class Shape
{
    //Fields
    private string _color;
    private float _x;
    private float _y;
    private int _width;
    private int _height;

    //Create constructor
    public Shape(int param)
    {
        _color = "Color.Chocolate"; // As my name is Min Thu Kyaw Khaung, the first letter 'M' which is after A-L.
        _x = 0.0f;
        _y = 0.0f;
        _width = (param);
        _height = param;
    }

    //Draw the shape
    public void Draw()
    {
        Console.WriteLine("Color is " + _color);
        Console.WriteLine("Position X is " + _x);
        Console.WriteLine("Position Y is " + _y);
        Console.WriteLine($"Position is ({_x},{_y})");
        Console.WriteLine("Width is " + _width);
        Console.WriteLine("Height is " + _height);
        Console.WriteLine();
    }

    //Check if the shape is at the position (xInput,yInput)
    //IsAt method
    public bool IsAt(int xInput, int yInput)
    {
        return (xInput > _x && xInput < (_x + _width) && yInput > _y && yInput < (_y + _height));
    }
    
    //Properties
    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public float X
    {
        get { return _x; }
        set { _x = value; }
    }
    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }
    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }
    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }
}