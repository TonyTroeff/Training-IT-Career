using System;
using System.Text;

namespace CreatingWords
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder(capacity: n);
            for (int i = 0; i < n; i++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());
                sb.Append(currentSymbol);
            }

            Console.WriteLine($"The word is: {sb}");
        }
    }
}