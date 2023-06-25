using System;
using System.Linq;
using System.Reflection;

namespace LongestSubSequenceOfCommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = SolveIteratively(array);

            //int[] dp = new int[array.Length];
            //Array.Fill(dp, -1);
            //int result = 0;
            //for (int i = 0; i < array.Length; i++)
            //    result = Math.Max(result, SolveRecursively(i, array, dp));

            Console.WriteLine($"The longest sub-sequence has length {result}");
        }

        static int SolveIteratively(int[] array)
        {
            int[] dp = new int[array.Length];
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int result = 0;

                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i]) result = Math.Max(result, dp[j]);
                }

                dp[i] = result + 1;
                max = Math.Max(max, dp[i]);
            }

            return max;
        }

        static int SolveRecursively(int index, int[] array, int[] dp)
        {
            if (dp[index] == -1)
            {
                int result = 0;

                for (int i = 0; i < index; i++)
                {
                    if (array[i] < array[index])
                        result = Math.Max(result, SolveRecursively(i, array, dp));
                }

                dp[index] = result + 1;
            }

            return dp[index];
        }
    }
}