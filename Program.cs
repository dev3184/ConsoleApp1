using System;
using System.Collections;
using System.Collections.Concurrent;
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



            // Collections Example
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add("Hello");
            list.Add(20);

            list.Insert(1, "World");
            list.Remove(10);

            Console.WriteLine("ArrayList Elements:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Hashtable table = new Hashtable();
            table.Add(1, "C#");
            table.Add(2, "Java");
            table.Add(3, "Python");

            foreach (DictionaryEntry item in table)
                Console.WriteLine(item.Key + " → " + item.Value);

            Stack stack = new Stack();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

            Console.WriteLine(stack.Pop()); // C
            Console.WriteLine(stack.Peek()); // B


            Queue queue = new Queue();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            Console.WriteLine(queue.Dequeue()); // First
            Console.WriteLine(queue.Peek()); // Second

            // Generic Collections 
            List<int> numbers = new List<int> { 1, 2, 3 };
            numbers.Add(4);
            numbers.Remove(2);
            numbers.Insert(1, 10);
            numbers.Sort();

            foreach (int n in numbers)
                Console.WriteLine(n);

            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Apple");
            dict.Add(2, "Banana");

            if (dict.ContainsKey(1))
                Console.WriteLine(dict[1]);

            HashSet<int> set = new HashSet<int> { 1, 2, 3 };
            set.Add(2); // ignored, duplicate
            set.Add(4);

            foreach (var i in set)
                Console.WriteLine(i);


            // Concurrent Collections 
            var dict1 = new ConcurrentDictionary<int, string>();

            Parallel.For(0, 5, i =>
            {
                dict1.TryAdd(i, "Value " + i);
            });

            foreach (var kvp in dict1)
                Console.WriteLine(kvp.Key + ": " + kvp.Value);

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