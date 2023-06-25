using System;
using System.Collections.Generic;

namespace SequenceOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateSequenceNumber(n, p));
        }

        static int CalculateSequenceNumber(int n, int p)
        {
            if (p == 0) return n;

            Queue<int> queue = new Queue<int>(capacity: p);
            queue.Enqueue(n);

            int index = 1;
            while (index < p)
            {
                int element = queue.Dequeue();

                queue.Enqueue(element + 1);
                if (++index != p)
                {
                    queue.Enqueue(element * 2);
                    index++;
                }
            }

            while (queue.Count > 1) queue.Dequeue();
            return queue.Dequeue();
        }
    }
}
