using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 147, 147)
        {

        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, _width, _height);

            if (Selected)
            {
                DrawOutline(7);
            }   
        }

        public override void DrawOutline(int x)
        {
            int outlineWidth = _width + (10 + x);
            int outlineHeight = _height + (10 + x);
            float outlineX = X - (5 + x / 2);
            float outlineY = Y - (5 + x / 2);

            SplashKit.DrawRectangle(Color.Black, outlineX, outlineY, outlineWidth, outlineHeight);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X >= X && pt.X <= (X + Width) && pt.Y >= Y && pt.Y <= (Y + Height);
        }
    }
}
