using System;
using SplashKitSDK;

namespace ShapeDrawer;

public class Shape
{
    //Fields
    private Color _color; //changed from string to Color
    private float _x;
    private float _y;
    private int _width;
    private int _height;

    //Create constructor
    public Shape(int param)
    {
        _color = Color.Chocolate; // As my name is Min Thu Kyaw Khaung, the first letter 'M' which is after A-L.
        _x = 0.0f;
        _y = 0.0f;
        _width = param;
        _height = param;
    }

    //Draw the shape
    public void Draw()
    {
        SplashKit.FillRectangle(_color, _x, _y, _width, _height); //changed from Console.WriteLine statements
    }

    //Check if the shape is at the position (xInput,yInput)
    //IsAt method
    public bool IsAt(Point2D pt)
    {
        return  pt.X >= _x && pt.X <= (_x + _width) &&
                pt.Y >= _y && pt.Y <= (_y + _height);
    }
    
    //Properties
    public Color Color
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