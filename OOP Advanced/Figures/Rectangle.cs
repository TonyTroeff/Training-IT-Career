using Figures.Interfaces;

namespace Figures
{
    public class Rectangle : IFigure, IDrawable
    {
        // TODO: Allow decimal values.
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double CalculatePerimeter() => 2 * (this.Width + this.Height);

        public double CalculateArea() => this.Width * this.Height;

        public void Draw(IWriter writer)
        {
            DrawLine(this.Width, '*', '*', writer);
            for (int i = 1; i < this.Height - 1; ++i)
                DrawLine(this.Width, '*', ' ', writer);
            DrawLine(this.Width, '*', '*', writer);
        }

        private void DrawLine(int width, char end, char mid, IWriter writer)
        {
            writer.WriteText(end);
            for (int i = 1; i < width - 1; ++i)
                writer.WriteText(mid);
            writer.WriteText(end);
            writer.WriteNewLine();
        }
    }
}
