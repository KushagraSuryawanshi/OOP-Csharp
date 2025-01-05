using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

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

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            EndX = endX;
            EndY = endY;
        }

        public MyLine() : this(Color.Red, 100, 100, 200, 200)
        {
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, EndX, EndY);

            if (Selected)
            {
                DrawOutline(7);
            }
        }

        public override void DrawOutline(int width)
        {
            SplashKit.DrawCircle(Color. Black, X, Y, width);
            SplashKit.DrawCircle(Color.Black, EndX, EndY, width);
        }

        public override bool IsAt(Point2D point)
        {

            float x1 = X;
            float y1 = Y;
            float x2 = EndX;
            float y2 = EndY;

            float rectX1 = Math.Min(x1, x2) ;
            float rectY1 = Math.Min(y1, y2) ;
            float rectX2 = Math.Max(x1, x2) ;
            float rectY2 = Math.Max(y1, y2) ;

            return point.X >= rectX1 && point.X <= rectX2 && point.Y >= rectY1 && point.Y <= rectY2;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();

            Console.WriteLine($"Loaded Line: Start({X}, {Y}) End({EndX}, {EndY})");

        }
    }

}
