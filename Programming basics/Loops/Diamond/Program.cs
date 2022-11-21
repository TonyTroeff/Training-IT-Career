using System;

namespace Diamond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rowsCount, innerDashes;
            if (n % 2 == 0)
            {
                rowsCount = n - 1;
                innerDashes = 0;
            }
            else
            {
                rowsCount = n;
                innerDashes = -1;
            }

            int outerDashes = rowsCount / 2;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < outerDashes; j++) Console.Write('-');

                Console.Write('*');
                for (int j = 0; j < innerDashes; j++) Console.Write('-');
                if (innerDashes >= 0) Console.Write('*');

                for (int j = 0; j < outerDashes; j++) Console.Write('-');

                Console.WriteLine();

                if (i < rowsCount / 2)
                {
                    outerDashes--;
                    innerDashes += 2;
                }
                else
                {
                    outerDashes++;
                    innerDashes -= 2;
                }
            }
        }
    }
}
