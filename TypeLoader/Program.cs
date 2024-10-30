using SafeActivator;
using System;

namespace TypeLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Activator.CreateInstance(typeof(object));
            Console.WriteLine("Hello, World!");
        }
    }
}
