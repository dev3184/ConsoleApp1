using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            I2DShape circle = new Circle(5);
            CalculateArea(circle);
            I2DShape rectangle = new Rectangle(4, 6);
            CalculateArea(rectangle);
            I3DShape sphere = new Sphere(4);
            CalculateArea(sphere);
            IPrinter printer = new Printer();
            printer.PrintArea(circle);
            printer.PrintArea(rectangle);
            printer.PrintArea(sphere);

        }
        private static void CalculateArea(I2DShape shape)
        {
            double area = shape.Area();
            Console.WriteLine($"Area of the circle: {area}");
        }
        private static void CalculateArea(I3DShape shape)
        {
            double volume = shape.Volume();
            Console.WriteLine($"Volume of the sphere: {volume}");
        }

    }
}