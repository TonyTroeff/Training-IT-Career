using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursion
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            /*List<string> results = new List<string>();
            GenerateAllNumbers(1, 1, n, new StringBuilder(capacity: n), results);

            foreach (string res in results)
                Console.WriteLine(res);*/

            Stack<int>[] rods = new Stack<int>[3];
            for (int i = 0; i < rods.Length; i++) rods[i] = new Stack<int>();
            for (int i = n; i >= 1; i--) rods[0].Push(i);

            TowersOfHanoi(n, rods, 0, 2, 1);
        }

        static void TowersOfHanoi(int bottomDisk, Stack<int>[] rods, int source, int destination, int sparse)
        {
            if (bottomDisk == 0)
                return;

            TowersOfHanoi(bottomDisk - 1, rods, source, sparse, destination);

            int disk = rods[source].Pop();
            rods[destination].Push(disk);

            Console.WriteLine();
            Console.WriteLine($"Moving number {disk} from rod #{source + 1} to rod #{destination + 1}");
            for (int i = 0; i < rods.Length; i++)
                Console.WriteLine($"Rod #{i + 1}: {string.Join(" ", rods[i].Reverse())}");

            TowersOfHanoi(bottomDisk - 1, rods, sparse, destination, source);
        }

        /*
        This works for fixed length only:
        for (int i1 = 1; i1 <= 9; i1++)
        {
            for (int i2 = 1; i2 <= 9; i2++)
            {
                for (int i3 = 1; i3 <= 9; i3++)
                {
                    if (i2 % i1 == 0 && i3 % i2 == 0)
                        Console.WriteLine($"{i1}{i2}{i3}");
                }
            }
        }*/
        private static void GenerateAllNumbers(int position, int modulus, int digits, StringBuilder numberBuilder, List<string> results)
        {
            if (position > digits)
            {
                results.Add(numberBuilder.ToString());
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (i % modulus != 0) continue;

                numberBuilder.Append(i);
                GenerateAllNumbers(position + 1, i, digits, numberBuilder, results);
                numberBuilder.Length--;
            }
        }
    }
}
