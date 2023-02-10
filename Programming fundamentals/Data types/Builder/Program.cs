using System;

namespace Builder
{
    public class Program
    {
        public static void Main()
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            sbyte sbytePrice;
            int intPrice;
            if (sbyte.TryParse(input1, out sbytePrice))
            {
                intPrice = int.Parse(input2);
            }
            else
            {
                sbytePrice = sbyte.Parse(input2);
                intPrice = int.Parse(input1);
            }

            long total = 10L * intPrice + 4 * sbytePrice;
            Console.WriteLine(total);
        }
    }
}