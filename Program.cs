using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            CalculateArea(circle);
            new Printer().PrintArea(circle);

        }
        private static void CalculateArea(Circle circle)
        {
            double area = circle.Area();
            Console.WriteLine($"Area of the circle: {area}");
        }
    }
}