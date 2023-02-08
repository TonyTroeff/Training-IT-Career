using System;

namespace ReversedCharacters
{
    public class Program
    {
        public static void Main()
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            char symbol3 = char.Parse(Console.ReadLine());
            Console.WriteLine($"{symbol3}{symbol2}{symbol1}");
        }
    }
}