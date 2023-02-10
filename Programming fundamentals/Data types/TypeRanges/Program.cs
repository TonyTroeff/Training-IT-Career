using System;

namespace TypeRanges
{
    public class Program
    {
        public static void Main()
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                Console.WriteLine(int.MaxValue);
                Console.WriteLine(int.MinValue);
            }
            else if (type == "uint")
            {
                Console.WriteLine(uint.MaxValue);
                Console.WriteLine(uint.MinValue);
            }
            else if (type == "long")
            {
                Console.WriteLine(long.MaxValue);
                Console.WriteLine(long.MinValue);
            }
            else if (type == "byte")
            {
                Console.WriteLine(byte.MaxValue);
                Console.WriteLine(byte.MinValue);
            }
            else if (type == "sbyte")
            {
                Console.WriteLine(sbyte.MaxValue);
                Console.WriteLine(sbyte.MinValue);
            }
        }
    }
}