using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    // Convert a schUML diagram to C#

    public interface IDrawObject
    {
        void DrawMe();
    }

    public class Blood : IDrawObject
    {
        public virtual void DrawMe()
        {
        }
    }

    public abstract class Shape : IDrawObject
    {
        public const double PI = Math.PI;
        protected double x;
        protected double y;

        private int myInt;

        public virtual double Area()
        {
            return this.x * this.y;
        }

        public abstract void DrawMe();

        public Shape()
        {

        }

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Circle : Shape, IDrawObject
    {
        public int myInt;

        public override double Area()
        {
            return Shape.PI * this.x * this.x;
        }

        public override void DrawMe()
        {
            // code that specifically draws a circle
        }

        public Circle(double r) : base(r,0)
        {
        }
    }

    public class Sphere : Shape
    {
        public override double Area()
        {
            return 4 * PI * this.x * this.x;
        }

        public override void DrawMe()
        {
            // code that specifically draws a sphere
        }

        public Sphere(double r) : base(r, 0)
        {
        }
    }

    internal class Cylinder : Shape
    {
        public override double Area()
        {
            return 2 * PI * this.x * this.x + 2 * PI * this.x * this.y;
        }

        public override void DrawMe()
        {
            // code that specifically draws a cylinder
        }

        public Cylinder(double r, double h) : base(r, h)
        {
        }
    }

    internal class Rectangle : Shape
    {
        public bool IsSquare
        {
            get
            {
                if(x == y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void DrawMe()
        {
            // code that specifically draws a rectangle
        }

        public Rectangle(double w, double h) : base (w, h)
        {

        }
    }

    static internal class Program
    {
        static void Main(string[] args)
        {
            // if MyMethod() is not static, then we need an instance of Program to call it
            // Program p = new Program();
            // p.MyMethod();
            MyMethod();

            Circle circle = new Circle(5.5);
            Cylinder cylinder = new Cylinder(3, 6);
            Rectangle rectangle = new Rectangle(1, 2);
            Blood blood = new Blood();

            Circle circle2;
            circle2 = circle;
            circle2.myInt = 1;

            Shape shape;

            // cannot instatiate an abstract class
            // shape = new Shape();

            // we can implicitly set a parent data type to a child data type
            shape = rectangle;

            // and it calls the method as defined in the child class
            // this will draw a rectangle
            shape.DrawMe();

            // this will calculate the area of a rectangle
            shape.Area();

            // but we do not have access to child class members that are not in the parent class
            //shape.IsSquare;

            // we can also access objects via interfaces that the object is derived from
            IDrawObject drawObject;

            // blood inherits the IDrawObject interface
            drawObject = blood;

            // this will draw blood
            drawObject.DrawMe();

            // circle inherits from the IDrawObject interface
            drawObject = circle;

            // this will draw a circle
            drawObject.DrawMe();

            // call DrawObject with each object
            DrawObject(circle);
            DrawObject(cylinder);
            DrawObject(blood);

            PrintAreaOfShape(rectangle);
        }

        // a generic method to draw an object via the IDrawObject interface
        // drawObject can point to the object passed in if that object inherits the IDrawObject interface
        // otherwise you will get a runtime error
        static void DrawObject( IDrawObject drawObject )
        {
            drawObject.DrawMe();
        }

        static void PrintAreaOfShape(Shape shape)
        {
            //if( shape.GetType() == typeof(Circle) ) 
            if( shape is Circle)
            {
                Console.WriteLine("You shape is a circle");
            }

            if( shape.GetType() == typeof(Rectangle))
            {
                Rectangle r;

                // we need to explicitly cast shape to be a Rectangle to access the IsSquare property
                // you can implicitly set a parent reference variable = a child data type (ie. shape = rectangle)
                // but you must explicitly cast a child data type to a parent data type (ie. r = shape)
                r = (Rectangle)shape;

                if( r.IsSquare )
                {
                    Console.WriteLine("You shape is a square");
                }
            }

            // this checks if shape inherits from IDrawObject interface
            if( shape is IDrawObject)
            {
                IDrawObject drawObject = (IDrawObject)shape;
                drawObject.DrawMe();
            }

            Console.WriteLine("The area is: " + shape.Area());
        }

        static void MyMethod()
        {

        }
    }
}
