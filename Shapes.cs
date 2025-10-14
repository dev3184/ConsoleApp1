using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Interface Segregation Principle Example
    public interface IShape
    { 
    }
    public interface I2DShape : IShape
    {
        double Area();
    }
    public interface I3DShape : IShape
    {
        double Volume();
    }
    public class Circle : I2DShape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double Area()
        {
            return Math.PI * radius * radius;
        }
        
    }
    public class Rectangle : I2DShape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double Area()
        {
            return length * width;
        }

    }
    public class Sphere : I3DShape
    {
        private double radius;
        public Sphere(double radius)
        {
            this.radius = radius;
        }
        public double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }
    }


    // Open/Closed Principle Violation Example

    //public class Circle
    //{
    //    private double radius;
    //    public Circle(double radius)
    //    {
    //        this.radius = radius;
    //    }
    //    public double Area()
    //    {
    //        return Math.PI * radius * radius;
    //    }
    //    public override string ToString()
    //    {
    //        return Area().ToString();
    //    }
    //}
    //public class Rectangle
    //{
    //    private double length;
    //    private double width;
    //    public Rectangle(double length, double width)
    //    {
    //        this.length = length;
    //        this.width = width;
    //    }
    //    public double Area()
    //    {
    //        return length * width;
    //    }

    //}
}
