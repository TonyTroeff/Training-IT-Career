using System;
using System.Text;

namespace ConcatBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate a string with length N over the english alphabet
            int n = int.Parse(Console.ReadLine());

            DateTime start = DateTime.Now;

            // 100 000 - 0.74
            // 200 000 - 4.06470
            // 1 000 000 - 232.27207
            /*string result = "";
            for (int i = 0; i < n; i++)
            {
                result += (char)('a' + i % 26);
            }*/

            // 100 000 - 0.00404
            // 200 000 - 0.00667
            // 1 000 000 - 0.00975
            StringBuilder result = new StringBuilder(capacity: n);
            for (int i = 0; i < n; i++)
            {
                result.Append((char)('a' + i % 26));
            }

            DateTime finish = DateTime.Now;
            TimeSpan diff = finish - start;
            string s = result.ToString();

            Console.WriteLine($"Elapsed seconds: {diff.TotalSeconds:f5}");
        }
    }
}