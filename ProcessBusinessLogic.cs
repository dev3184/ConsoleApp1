using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProcessBusinessLogic
    {
        public delegate void Notify(); // Delegate declaration

        public event Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started...");
            // Some logic here
            Thread.Sleep(2000); // Simulate work
            OnProcessCompleted(); // Raise the event
        }

        // Method to raise event
        protected virtual void OnProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
            ProcessCompleted?.Invoke();  // Raise event safely
        }
    }
}
