using System;
using SplashKitSDK;

namespace ShapeDrawer;
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Shape myShape = new Shape(181);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // Check if left mouse button is clicked
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Move the shape to where the mouse was clicked
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                // Check if spacebar is pressed and mouse is over the shape
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // Get the current mouse position
                    Point2D mousePos = SplashKit.MousePosition();
                    
                    // Check if the mouse is over the shape
                    if (myShape.IsAt(mousePos))
                    {
                        // Change the shape to a random color
                        myShape.Color = SplashKit.RandomColor();
                    }
                }

                // Draw the shape
                myShape.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
