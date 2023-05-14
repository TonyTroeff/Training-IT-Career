using System;

namespace StaticGeometry
{
    internal static class Geometry
    {
        internal static double RectanglePerimeter(double a, double b)
            => 2 * (a + b);

        internal static double RectangleArea(double a, double b)
            => a * b;

        internal static double SquarePerimeter(double a)
            => 4 * a;

        internal static double SquareArea(double a)
            => a * a;

        internal static double CircleArea(double r)
            => Math.PI * r * r;
    }
}
