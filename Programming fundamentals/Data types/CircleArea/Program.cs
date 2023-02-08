using System;

namespace CircleArea
{
    public class Program
    {
        public static void Main()
        {
            double radius = double.Parse(Console.ReadLine());
            double area = radius * radius * Math.PI;
            Console.WriteLine($"{area:f12}");
        }
    }
}