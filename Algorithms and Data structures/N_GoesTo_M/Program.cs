using System;
using System.Collections.Generic;

namespace N_GoesTo_M
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            // List<int> result = SolveRecursively(n, m, new Dictionary<int, List<int>>());
            // List<int> result = SolveIteratively(n, m);
            List<int> result = SolveUsingBfs(n, m);
            if (result == null) Console.WriteLine("This is not possible.");
            else Console.WriteLine(string.Join(", ", result));
        }

        static List<int> SolveUsingBfs(int n, int m)
        {
            if (n > m) return null;
            if (n == m) return new List<int>(capacity: 1) { m };

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            int[] dp = new int[m - n + 1];
            Array.Fill(dp, -1);

            while (dp[^1] == -1)
            {
                int current = queue.Dequeue();
                int[] options = new[] { current * 2, current + 2, current + 1 };
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i] > m) continue;

                    // QUESTION: Is this always true?
                    if (dp[options[i] - n] != -1) continue;

                    dp[options[i] - n] = current;
                    queue.Enqueue(options[i]);
                }
            }

            Stack<int> minPath = new Stack<int>();
            int iter = m;
            while (iter != -1)
            {
                minPath.Push(iter);
                iter = dp[iter - n];
            }

            List<int> result = new List<int>(capacity: minPath.Count);
            while (minPath.Count > 0) result.Add(minPath.Pop());

            return result;
        }

        static List<int> SolveIteratively(int n, int m)
        {
            if (n > m) return null;

            int length = m - n + 1;
            List<int>[] dp = new List<int>[length];

            dp[^1] = new List<int>(capacity: 1) { m };
            for (int i = m - 1; i >= n; i--)
            {
                int[] options = new[] { i + 1, i + 2, i * 2 };
                List<int> minPath = null;

                for (int j = 0; j < options.Length; j++)
                {
                    if (options[j] > m) continue;

                    // List<int> preComputedPathForOption = dp[^(m - options[j] + 1)];
                    List<int> preComputedPathForOption = dp[options[j] - n];
                    if (minPath == null || preComputedPathForOption.Count < minPath.Count)
                        minPath = preComputedPathForOption;
                }

                List<int> finalResult = null;
                if (minPath != null)
                {
                    finalResult = new List<int>(capacity: 1 + minPath.Count) { i };
                    finalResult.AddRange(minPath);
                }

                // dp[^(m - i + 1)] = finalResult;
                dp[i - n] = finalResult;
            }

            return dp[0];
        }

        static List<int> SolveRecursively(int n, int m, Dictionary<int, List<int>> memo)
        {
            if (n == m) return new List<int>(capacity: 1) { m };
            if (n > m) return null;
            if (memo.ContainsKey(n)) return memo[n];

            List<int> min = null;

            List<int> result1 = SolveRecursively(n + 1, m, memo);
            if (result1 != null) min = result1;

            List<int> result2 = SolveRecursively(n + 2, m, memo);
            if (result2 != null && (min == null || result2.Count < min.Count)) min = result2;

            List<int> result3 = SolveRecursively(n * 2, m, memo);
            if (result3 != null && (min == null || result3.Count < min.Count)) min = result3;

            if (min == null) return null;

            var finalResult = new List<int>(capacity: min.Count + 1) { n };
            finalResult.AddRange(min);

            memo[n] = finalResult;
            return finalResult;
        }
    }
}
