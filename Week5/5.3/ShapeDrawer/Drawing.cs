using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        public  Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing (Color background)
        {
            _shapes = new List<Shape> ();
            _background = background;
        }
        
        public Drawing(): this(Color.White)
        {

        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void RemoveShape(Shape shape)
        {
            _ = _shapes.Remove(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
            SplashKit.RefreshScreen();
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                shape.Selected = shape.IsAt(pt);
            }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }
                return result;
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
 
            writer.WriteColor(_background);
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }

        public void Load(string filename)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename);
                _background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    string kind = reader.ReadLine();
                    Shape s = null;
                    if (kind == "Rectangle")
                    {
                        s = new MyRectangle();
                    }
                    else if (kind == "Circle")
                    {
                        s = new MyCircle();
                    }
                    else if (kind == "Line")
                    {
                        s = new MyLine();
                    }
                    else
                    {
                        Console.WriteLine($"Skipping unknown shape kind: {kind}");
                        continue;
                    }

                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


    }
}
