using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer;

public class Program
{
    // Private enumeration for shape kinds
    private enum ShapeKind
    {
        Rectangle,
        Circle,
        Line
    }

    public static void Main()
    {
        Window window = new Window("Shape Drawer - Multiple Shape Kinds", 800, 600);

        // Create a new Drawing object
        Drawing myDrawing = new Drawing();

        // Variable to track which kind of shape to add
        ShapeKind kindToAdd = ShapeKind.Circle;

        // Number of parallel lines (last digit of student ID is 1, so X=1)
        int parallelLines = 1;

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            // Step 8.4: Check for R key to select Rectangle
            if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                kindToAdd = ShapeKind.Rectangle;
            }

            // Step 8.4: Check for C key to select Circle
            if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                kindToAdd = ShapeKind.Circle;
            }

            // Step 26: Check for L key to select Line
            if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                kindToAdd = ShapeKind.Line;
            }

            // Check if left mouse button is clicked
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                // Get mouse position
                float mouseX = SplashKit.MouseX();
                float mouseY = SplashKit.MouseY();

                // Declare myShape variable
                Shape? myShape = null;

                if (kindToAdd == ShapeKind.Rectangle)
                {
                    myShape = new MyRectangle();
                }
                else if (kindToAdd == ShapeKind.Circle)
                {
                    myShape = new MyCircle();
                }
                else  // Line
                {
                    // Step 26: Draw parallelLines number of lines at the same time
                    for (int i = 0; i < parallelLines; i++)
                    {
                        Shape lineShape = new MyLine(Color.Red, mouseX, mouseY + (i * 10), mouseX + 100, mouseY + (i * 10));
                        myDrawing.AddShape(lineShape);
                    }
                }

                // Add the shape to the drawing
                if (myShape != null)
                {
                    // Step 9: Fix code duplication - set position once for all shapes
                    myShape.X = mouseX;
                    myShape.Y = mouseY;
                    myDrawing.AddShape(myShape);
                }
            }

            // Check if spacebar is pressed
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                // Change the background color to a new random color
                myDrawing.Background = SplashKit.RandomColor();
            }

            // Check if right mouse button is clicked
            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                // Get current mouse position
                Point2D mousePos = SplashKit.MousePosition();
                // Tell myDrawing to SelectShapesAt the current mouse pointer position
                myDrawing.SelectShapesAt(mousePos);
            }

            // Check if Delete key or Backspace key is pressed
            if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                // Get all selected shapes and remove them from the drawing
                List<Shape> selectedShapes = myDrawing.SelectedShapes;
                foreach (Shape shape in selectedShapes)
                {
                    myDrawing.RemoveShape(shape);
                }
            }

            // Tell myDrawing to Draw
            myDrawing.Draw();

            SplashKit.RefreshScreen();

        } while (!window.CloseRequested);
    }
}