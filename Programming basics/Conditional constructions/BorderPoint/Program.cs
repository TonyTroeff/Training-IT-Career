using System;

namespace BorderPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool laysOnHorizontalBorder = (y1 == y || y2 == y) && x1 <= x && x <= x2;
            bool laysOnVerticalBorder = (x1 == x || x2 == x) && y1 <= y && y <= y2;
            if (laysOnHorizontalBorder || laysOnVerticalBorder) Console.WriteLine("Border");
            else Console.WriteLine("Inside/Outside");
        }
    }
}
