using System;

namespace SameWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine().ToLower();
            string b = Console.ReadLine().ToLower();

            if (a == b) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
