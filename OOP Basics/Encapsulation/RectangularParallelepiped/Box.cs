using System;

namespace RectangularParallelepiped
{
    internal class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            if (length <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            if (width <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            if (height <= 0) throw new ArgumentException("Height cannot be zero or negative.");

            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double CalculateSurfaceArea()
            => this.CalculateLateralSurfaceArea() + 2 * this.width * this.length;

        public double CalculateLateralSurfaceArea()
            => 2 * this.width * this.height + 2 * this.length * this.height;

        public double CalculateVolume() => this.width * this.length * this.height;
    }
}
