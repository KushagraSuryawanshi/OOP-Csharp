using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Drawing mydrawing = new Drawing();

            ShapeKind kindToAdd = ShapeKind.Circle;

            int LinesToAdd = 7;

            string savePath = @"C:\Users\kusha\Sem2\Object Oriented Programming C#\Programming Assignments\Week5\5.3\TestDrawing.txt";

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                Point2D mousePosition = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    mydrawing.Background = SplashKit.RandomColor();
                }
                else if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in mydrawing.SelectedShapes.ToList())
                    {
                        mydrawing.RemoveShape(shape);
                    }
                }
                else if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    mydrawing.Save(savePath);
                    Console.WriteLine($"Drawing saved to {savePath}");
                }
                else if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        mydrawing.Load(savePath);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = null;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;
                        case ShapeKind.Line:

                            if (LinesToAdd > 0)
                            {
                                float endX = 300; 
                                float endY = 300;
                                newShape = new MyLine { X = SplashKit.MouseX(), Y = SplashKit.MouseY(), EndX = endX, EndY = endY };

                                mydrawing.AddShape(newShape);
                                LinesToAdd--; 

                                if (LinesToAdd == 0)
                                {
                                    kindToAdd = ShapeKind.Rectangle;
                                }
                            }
                            break;
                        default:
                            newShape = new MyRectangle();
                            break;
                    }

                    if(newShape != null)
                    {
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        mydrawing.AddShape(newShape);
                    }

                }
                
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    mydrawing.SelectShapesAt(mousePosition);
                }

                mydrawing.Draw();

                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);

        }
    }
}

