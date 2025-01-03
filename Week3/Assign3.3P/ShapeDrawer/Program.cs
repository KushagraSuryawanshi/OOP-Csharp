using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Drawing mydrawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                Point2D mousePosition = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = new Shape(50);
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();

                    mydrawing.AddShape(newShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) 
                {
                    mydrawing.Background = SplashKit.RandomColor();
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    mydrawing.SelectShapesAt(mousePosition);
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in mydrawing.SelectedShapes.ToList()) 
                    {
                        mydrawing.RemoveShape(shape);
                    }
                }


                mydrawing.Draw();

                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);

        }
    }
}
