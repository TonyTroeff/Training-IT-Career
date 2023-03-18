using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfTwoNames
{
    public class Program
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split(", ");
            Array.Reverse(names);

            /*List<string> names = Console.ReadLine().Split(", ").ToList();
            names.Reverse();*/

            foreach (string name in names)
            {
                string[] nameSegments = name.Split();
                Console.WriteLine($"{nameSegments[1]} {nameSegments[0]}");
            }
        }
    }
}