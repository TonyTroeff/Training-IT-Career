using System;
using System.Text;

namespace MessageDecryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder(capacity: n);
            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sb.Append((char)(symbol + key));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}