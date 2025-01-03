using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }
        public MyCircle() : this(Color.Blue, 97)
        {
        }

        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, _radius);

            if (Selected)
            {
                DrawOutline(7);
            }
        }

        public override void DrawOutline(int x)
        {
            int RadiusOutline = _radius + 2;

            SplashKit.DrawCircle(Color.Black, X, Y, RadiusOutline);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt.X, pt.Y, X, Y, _radius);
        }

    }
}
