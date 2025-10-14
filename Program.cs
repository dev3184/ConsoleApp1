using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle(5);
            CalculateArea(circle);
            IShape rectangle = new Rectangle(4, 6);
            CalculateArea(rectangle);
            new Printer().PrintArea(circle);
            new Printer().PrintArea(rectangle);

        }
        private static void CalculateArea(IShape shape)
        {
            double area = shape.Area();
            Console.WriteLine($"Area of the circle: {area}");
        }
       
    }
}