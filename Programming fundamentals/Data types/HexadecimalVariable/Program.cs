using System;

namespace HexadecimalVariable
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input, 16);
            Console.WriteLine(number);
        }
    }
}