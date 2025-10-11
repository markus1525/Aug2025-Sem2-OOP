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

        // Step 9: File path for saving/loading - 
        string filePath = "/Users/minthukyawkhaung/Desktop/TestDrawing.txt"; // Mac
                                                                             //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestDrawing.txt"); //Cross-platform

        string statusMessage = ""; //week 7 verification task

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            // Check for R key to select Rectangle
            if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                kindToAdd = ShapeKind.Rectangle;
            }

            // Check for C key to select Circle
            if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                kindToAdd = ShapeKind.Circle;
            }

            // Check for L key to select Line
            if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                kindToAdd = ShapeKind.Line;
            }

            // Step 9: Check for S key to save
            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                try
                {
                    myDrawing.Save(filePath);
                    Console.WriteLine("Drawing saved successfully to: " + filePath);
                    statusMessage = "Drawing Saved to File.";
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Error saving file: {0}", e.Message);
                }
            }

            // Step 16: Check for O key to open/load
            if (SplashKit.KeyTyped(KeyCode.OKey))
            {
                try
                {
                    myDrawing.Load(filePath);
                    Console.WriteLine("Drawing loaded successfully from: " + filePath);
                    statusMessage = "Drawing Loaded from File.";
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Error loading file: {0}", e.Message);
                }
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
                    // Draw parallelLines number of lines at the same time
                    for (int i = 0; i < parallelLines; i++)
                    {
                        Shape lineShape = new MyLine(Color.Red, mouseX, mouseY + (i * 10), mouseX + 100, mouseY + (i * 10));
                        myDrawing.AddShape(lineShape);
                    }
                }

                // Add the shape to the drawing
                if (myShape != null)
                {
                    // Fix code duplication - set position once for all shapes
                    myShape.X = mouseX;
                    myShape.Y = mouseY;
                    myDrawing.AddShape(myShape);
                }
                // Clear message when shape is added
                statusMessage = ""; //week 7 verification task
            }

            // Check if spacebar is pressed
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                // Change the background color to a new random color
                myDrawing.Background = SplashKit.RandomColor();

                // Clear message when background color is changed
                statusMessage = ""; //verification task (c)
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
                // Clear message when shapes are deleted
                statusMessage = ""; //week 7 verification task
            }

            // Tell myDrawing to Draw
            myDrawing.Draw();

            //week 7 verification task
            // Display status message if not empty
            if (statusMessage != "")
            {
                int textWidth = statusMessage.Length * 8;
                int xPosition = (800 - textWidth) / 2;
                int yPosition = 30;

                SplashKit.DrawRectangle(Color.Red, xPosition - 15, yPosition - 8, textWidth + 30, 25);

                SplashKit.DrawText(statusMessage, Color.Red, xPosition, yPosition);
            }

            SplashKit.RefreshScreen();

        } while (!window.CloseRequested);
    }
}