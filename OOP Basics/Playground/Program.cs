using Playground.Classes;
using System;
using System.Collections.Generic;

namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(capacity: 10);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            list.Add(10);

            // <type> <variable_name> = new <type>();
            // Instantiation - To create an instance of a given type.

            Door doorVariable = new Door();

            // 1. Static invocation -> Door.Method()
            // 2. Instance invocation -> doorVariable.Method()
            for (int i = 0; i < 5; i++) doorVariable.Print();

            doorVariable.Height = 10;
            // doorVariable.set_Height(10);

            Console.WriteLine(doorVariable.Height);
            // Console.WriteLine(doorVariable.get_Height());

            // There are two main ways to implement an abstract data type in C#:
            // - class (reference types)
            // - struct (value type)
            // - ref struct
            // - readonly struct
            // - record struct
        }
    }
}