using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer;
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer - Multiple Shapes", 800, 600);
            
            // Create a new Drawing object
            Drawing myDrawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();

                // Check if left mouse button is clicked
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Create a new Shape object using the default constructor
                    Shape myShape = new Shape(181);
                    
                    // Move the shape to where the mouse was clicked
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    
                    // Add the shape to the drawing
                    myDrawing.AddShape(myShape);
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
