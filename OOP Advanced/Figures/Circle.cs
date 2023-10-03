using Figures.Interfaces;

namespace Figures
{
    // This class is closed for modification
    // The `Draw` method is open for extension (in terms of where the output is being written)
    public class Circle : IFigure, IDrawable
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public double CalculateArea() => Math.PI * this.Radius * this.Radius;

        public void Draw(IWriter writer)
        {
            double r_in = this.Radius - 0.4;
            double r_out = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < r_out; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= r_in * r_in && value <= r_out * r_out)
                        writer.WriteText("*");
                    else
                        writer.WriteText(" ");
                }

                writer.WriteNewLine();
            }
        }
    }
}
