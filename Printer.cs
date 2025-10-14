using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Printer
    {
        public void PrintArea(IShape shape)
        {
            Console.WriteLine($"Area of the shape: {shape}");
        }
        
    }
}
