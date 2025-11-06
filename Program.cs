using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AreaDelegate areaDelegate = new AreaDelegate(CalculateArea);    
            VolumeDelegate volumeDelegate = new VolumeDelegate(CalculateArea);
            I2DShape circle = new Circle(5);
            areaDelegate(circle);
            I2DShape rectangle = new Rectangle(4, 6);
            areaDelegate(rectangle);
            I3DShape sphere = new Sphere(4);
            volumeDelegate(sphere);
            IPrinter printer = new Printer();
            printer.PrintArea(circle);
            printer.PrintArea(rectangle);
            printer.PrintArea(sphere);
            Console.WriteLine(circle.ToDetailedString());

            //Events and Delegate example 

            ProcessBusinessLogic process = new ProcessBusinessLogic();

            // Subscribe to the event
            process.ProcessCompleted += ProcessCompletedHandler;

            process.StartProcess();

            Console.ReadKey();

            //SystemExceptions
            try
            {
                int[] arr = new int[3];
                Console.WriteLine(arr[5]);  // IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                string s = null;
                Console.WriteLine(s.Length);  // NullReferenceException
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                int x = int.Parse("abc");  // FormatException
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                using (var reader = new StreamReader("nofile.txt"))  // FileNotFoundException
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            // ApplicationException Example 
            try
            {
                Account acc = new Account(1000);
                acc.Withdraw(2000);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"{ex.Message} Current balance: {ex.CurrentBalance}");
            }

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
        public delegate void AreaDelegate(I2DShape shape);
        public delegate void VolumeDelegate(I3DShape shape);

        static void ProcessCompletedHandler()
        {
            Console.WriteLine("Notification: Process has completed successfully!");
        }
        


    }
    public static class ExtensionMethods
    {
        public static string ToDetailedString(this IShape shape)
        {
            switch (shape)
            {
                case I2DShape twoDShape:
                    return $"2D Shape with Area: {twoDShape.Area()}";
                case I3DShape threeDShape:
                    return $"3D Shape with Volume: {threeDShape.Volume()}";
                default:
                    return "Unknown Shape";
            }
        }
    }

    // ApplicationException example 
    public class InsufficientFundsException : Exception
    {
        public double CurrentBalance { get; }

        public InsufficientFundsException(string message, double currentBalance)
            : base(message)
        {
            CurrentBalance = currentBalance;
        }
    }

    class Account
    {
        public double Balance { get; private set; }

        public Account(double balance)
        {
            Balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
                throw new InsufficientFundsException("Insufficient funds!", Balance);
            Balance -= amount;
        }
    }

}