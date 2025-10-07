using System;
using SplashKitSDK;

namespace ShapeDrawer;

public class MyLine : Shape
{
    // Fields
    private float _endX;
    private float _endY;

    // Default constructor
    public MyLine() : this(Color.Red, 0.0f, 0.0f, 100.0f, 100.0f)
    {
    }

    // Overloaded constructor
    public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
    {
        X = startX;
        Y = startY;
        _endX = endX;
        _endY = endY;
    }

    // Properties
    public float EndX
    {
        get { return _endX; }
        set { _endX = value; }
    }

    public float EndY
    {
        get { return _endY; }
        set { _endY = value; }
    }

    // Override Draw method
    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.DrawLine(Color, X, Y, _endX, _endY);
    }

    // Override DrawOutline method
    public override void DrawOutline()
    {
        // Draw small circles around the start and end points
        SplashKit.FillCircle(Color.Gold, X, Y, 5); //verification task
        SplashKit.FillCircle(Color.Gold, _endX, _endY, 5); //verification task
    }

    // Override IsAt method
    public override bool IsAt(Point2D pt)
    {
        // Check if the point is on the line using SplashKit's helper method
        // Adding a small tolerance for easier selection
        Line line = SplashKit.LineFrom(X, Y, _endX, _endY);
        return SplashKit.PointOnLine(pt, line, 5.0f);
    }
}