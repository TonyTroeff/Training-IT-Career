using System;

namespace PyramidVolume
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = (length * width * height) / 3;
            
            Console.WriteLine($"Pyramid Volume: {volume:F2}");
        }
    }
}