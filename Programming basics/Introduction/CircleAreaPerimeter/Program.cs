using System;

namespace CircleAreaPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double area = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;

            Console.WriteLine($"Area = {Math.Round(area, 2)}");
            Console.WriteLine($"Perimeter = {Math.Round(perimeter, 2)}");
        }
    }
}
