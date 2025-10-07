using System;
using SplashKitSDK;

namespace ShapeDrawer;

public class MyCircle : Shape
{
    // Fields
    private int _radius;

    // Default constructor
    public MyCircle() : this(Color.Blue, 0.0f, 0.0f, 131)
    {
        // Using 131 (50 + 81, where 81 is the last two digits)
    }

    // Overloaded constructor
    public MyCircle(Color color, float x, float y, int radius) : base(color)
    {
        X = x;
        Y = y;
        _radius = radius;
    }

    // Properties
    public int Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }

    // Override Draw method
    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.FillCircle(Color, X, Y, _radius);
    }

    // Override DrawOutline method
    public override void DrawOutline()
    {
        // Draw a black circle with a radius 2 pixels larger
        SplashKit.DrawCircle(Color.Fuchsia, X, Y, _radius + 2); //verification task
    }

    // Override IsAt method
    public override bool IsAt(Point2D pt)
    {
        // Check if the point is within the circle using SplashKit's helper method
        return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
    }
}