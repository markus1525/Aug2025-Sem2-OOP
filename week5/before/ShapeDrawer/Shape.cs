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
    private bool _selected; // Add selected field

    //Default constructor for creating new shapes on the fly
    public Shape()
    {
        _color = Color.Green;
        _x = 0.0f;
        _y = 0.0f;
        _width = 100;
        _height = 100;
        _selected = false;
    }

    //Original constructor
    public Shape(int param)
    {
        _color = Color.Chocolate; // As my name is Min Thu Kyaw Khaung, the first letter 'M' which is after A-L.
        _x = 0.0f;
        _y = 0.0f;
        _width = param;
        _height = param;
        _selected = false; // Initialize selected to false
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

    // Add a property for selected
    public bool Selected
    {
        get { return _selected; }
        set { _selected = value; }
    }

    //Draw the shape
    public void Draw()
    {
        SplashKit.FillRectangle(_color, _x, _y, _width, _height); //changed from Console.WriteLine statements
        if (_selected) // Draw a border if selected
        {
            DrawOutline();
        }
    }

    //Draw outline around the shape
    public void DrawOutline()
    {
        // The outline is 6 pixels wider on all sides (5 + 1 (Last ID))
        SplashKit.DrawRectangle(Color.Black, _x - 6, _y - 6, _width + 12, _height + 12);
    }

    ///Check if the point is within the shape's bounds
    public bool IsAt(Point2D pt)
    {
        return pt.X >= _x && pt.X <= (_x + _width) &&
                pt.Y >= _y && pt.Y <= (_y + _height);
    }
}