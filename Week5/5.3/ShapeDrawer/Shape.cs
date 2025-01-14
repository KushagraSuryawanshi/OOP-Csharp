﻿using MyGame;
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

    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;


        public Shape(Color color)
        {
            _x = 0.0f;
            _y = 0.0f;
            _color = color;
        }

        public Shape() : this(Color.Yellow)
        {

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



        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);
        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public abstract void DrawOutline(int x);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger(); 
            Y = reader.ReadInteger(); 
        }

    }
}
