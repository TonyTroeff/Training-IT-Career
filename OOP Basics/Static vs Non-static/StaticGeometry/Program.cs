using System;

namespace StaticGeometry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int type = int.Parse(Console.ReadLine());

            switch (type)
            {
                case 1:
                    SquarePerimeter();
                    break;
                case 2:
                    SquareArea();
                    break;
                case 3:
                    RectanglePerimeter();
                    break;
                case 4:
                    RectangleArea();
                    break;
                case 5:
                    CircleArea();
                    break;
            }
        }

        static void SquarePerimeter()
        {
            double side = double.Parse(Console.ReadLine());
            Console.WriteLine(Geometry.SquarePerimeter(side));
        }

        static void SquareArea()
        {
            double side = double.Parse(Console.ReadLine());
            Console.WriteLine(Geometry.SquareArea(side));
        }

        static void RectanglePerimeter()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            Console.WriteLine(Geometry.RectanglePerimeter(sideA, sideB));
        }

        static void RectangleArea()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            Console.WriteLine(Geometry.RectangleArea(sideA, sideB));
        }

        static void CircleArea()
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine(Geometry.CircleArea(r));
        }
    }
}
