using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {

            Shape myShape = new Shape(147);

            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                Point2D mousePosition = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

 
                if(SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    if (myShape.IsAt(mousePosition))
                    {
                        myShape.Color = SplashKit.RandomColor();
                    }
                }

                myShape.Draw();

                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);

        }
    }
}
