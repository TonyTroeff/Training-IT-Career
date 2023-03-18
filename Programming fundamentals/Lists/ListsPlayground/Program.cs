using System;
using System.Collections.Generic;

namespace ListsPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> names = new List<string>();
            names.Add("Peter");
            names.Add("Smith");
            names.Add("Gosho");
            names.Add("Tony");

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");

            Console.WriteLine("Removing element at index 1");
            names.RemoveAt(1);

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");

            Console.WriteLine("Inserting Barry at index 2");
            names.Insert(2, "Barry");

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");

            Console.WriteLine("Replacing Tony with Ronnie");
            names[3] = "Ronnie";

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");

            Console.WriteLine("Adding Mark 3 times");
            names.Add("Mark");
            names.Insert(1, "Mark");
            names.Add("Mark");

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");

            Console.WriteLine("Removing Mark");
            names.Remove("Mark");

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");

            Console.WriteLine("Removing all occurrences of Mark");
            bool canRemove = names.Remove("Mark");
            while (canRemove) canRemove = names.Remove("Mark");

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"{i} -> {names[i]}");
        }
    }
}