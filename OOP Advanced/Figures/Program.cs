using Figures.Interfaces;

namespace Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            // IWriter writer = new FileWriter("output.txt");

            Console.Write("Enter the circle radius: ");
            double radius = double.Parse(Console.ReadLine());

            Circle circle = new Circle(radius);
            Console.WriteLine($"The perimeter of the circle is: {circle.CalculatePerimeter():f2}");
            Console.WriteLine($"The area of the circle is: {circle.CalculateArea():f2}");
            circle.Draw(writer);

            Console.Write("Enter the rectangle width: ");
            int width = int.Parse(Console.ReadLine());

            Console.Write("Enter the rectangle height: ");
            int height = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(width, height);
            Console.WriteLine($"The perimeter of the rectangle is: {rectangle.CalculatePerimeter():f2}");
            Console.WriteLine($"The area of the rectangle is: {rectangle.CalculateArea():f2}");
            rectangle.Draw(writer);

            /*
            object testObj1 = circle;
            Console.WriteLine($"Circle is drawable: {testObj1 is IDrawable}");
            Console.WriteLine($"Circle is object: {testObj1 is object}");
            Console.WriteLine($"Circle is rectangle: {testObj1 is Rectangle}");

            // This is called "pattern matching"
            if (testObj1 is IDrawable drawable)
            {
                // The following line will not compile because testObj1 is an instance of type "object".
                // testObj1.Draw(writer);
                drawable.Draw(writer);

                Console.WriteLine($"`testObj1` is the same as `drawable`: {ReferenceEquals(testObj1, drawable)}");
            }

            object testObj2 = rectangle;
            Console.WriteLine($"Rectangle is drawable: {testObj2 is IDrawable}");
            Console.WriteLine($"Rectangle is object: {testObj2 is object}");
            Console.WriteLine($"Rectangle is circle: {testObj2 is Circle}");
            */
        }
    }
}