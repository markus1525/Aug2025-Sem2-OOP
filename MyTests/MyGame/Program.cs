using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window window = new Window("Hello SplashKit", 800, 600);

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();
            
            // Add your drawing code here

            SplashKit.RefreshScreen(60);
        } while (!window.CloseRequested);
    }
}