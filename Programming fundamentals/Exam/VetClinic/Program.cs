using System;

namespace VetClinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                string t = Console.ReadLine();
                if (t == "scalpel") sum += 1500;
                else if (t == "microscope") sum += 6000;
                else if (t == "syringe") sum += 100;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}