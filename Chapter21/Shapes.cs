namespace Shapes
{
      using System.Drawing;


   public class Circle
   {
      double Radius;
   
      public Circle()
      {
         Radius = 0;
      }

      public Circle(double givenRadius)
      {
         Radius = givenRadius;
      }

      
      public void Draw() 
      {
         Pen p = new Pen(Color.Red);
      }

      public double Area() 
      {
         // area = pi r squared
         return System.Math.PI * (Radius * Radius);
      }
   }

   public class Triangle
   {
      double Base;      
      double Height;
   
      public Triangle()
      {
         Base = 0;
         Height = 0;
      }

      public Triangle(double givenBase, double givenHeight)
      {
         Base = givenBase;
         Height = givenHeight;
      }

      public double Area() 
      {
         return 0.5F * Base * Height;  // area = 1/2 base * height
      }
   }
}
