using System;

namespace TriangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = CalculateArea(side, height);
            Console.WriteLine(area);
        }

        static double CalculateArea(double side, double height)
        {
            return side * height / 2;
        }
    }
}
