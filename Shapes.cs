using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IShape
    {
        double Area();
    }
    public class Circle : IShape
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
    public class Rectangle : IShape
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
