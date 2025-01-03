using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public struct Point2D
    {
        public float X;
        public float Y;

        public Point2D(float x, float y)
        {
             X = x; Y = y; 
        }
    }

    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        public Shape(int param)
        {
            string firstName = "Kushagra";
            char firstLetter = firstName[0];

            if(firstLetter >= 'A' && firstLetter <= 'K')
            {
                _color = Color.Azure;
            }
            else
            {
                _color = Color.Chocolate;
            }

            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

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

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
           
            if (_selected)
            {
                DrawOutline(7);
            }
        }

        public bool IsAt(Point2D pt)
        {
            if ( pt.X >= _x &&  pt.X <=(_x + _width) && pt.Y >= _y && (pt.Y <= (_y + _height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public void DrawOutline(int x)
        {
            int outlineWidth = _width + (10 + x);  
            int outlineHeight = _height + (10 + x);  
            float outlineX = _x - (5 + x / 2);
            float outlineY = _y - (5 + x / 2);

            SplashKit.DrawRectangle(Color.Black, outlineX, outlineY, outlineWidth, outlineHeight);
        }


    }
}
