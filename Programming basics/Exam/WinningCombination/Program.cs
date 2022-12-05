using System;

namespace WinningCombination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;
            for (int i1 = Math.Max(0, n - 9); i1 <= Math.Min(9, n); i1++)
            {
                for (int i3 = 0; i3 <= 8; i3 += 2)
                {
                    for (int i4 = 0; i4 <= 9; i4 += 9)
                    {
                        for (int i5 = 3; i5 <= 6; i5 += 3)
                        {
                            Console.Write($"{i1}{n - i1}{i3}{i4}{i5} ");
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine($"Count of winner numbers: {count}");
        }
    }
}
