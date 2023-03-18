using System;
using System.Collections.Generic;

namespace HashSetPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            HashSet<int> hashSet = new HashSet<int>();

            /*list.Add(1);
            list.Insert(0, -5);
            list.RemoveAt(1);
            list[0] = -3;
            Console.WriteLine(list[0]);

            hashSet.Add(1);*/

            for (int i = 0; i < 200000; i++)
            {
                list.Add(i);
                hashSet.Add(i);
            }

            DateTime start = DateTime.Now;

            /*// Took 1.98541s.
            for (int i = 0; i < 200000; i++)
            {
                bool listContainsI = list.Contains(i);
            }*/

            /*// Took 0.01384s.
            for (int i = 0; i < 200000; i++)
            {
                bool hashSetContainsI = hashSet.Contains(i);
            }*/

            /*// Took 3.98096s.
            for (int i = 0; i < 200000; i++)
            {
                bool listContainsI = list.Contains(i * -1);
            }*/

            /*// Took 0.00929s.
            for (int i = 0; i < 200000; i++)
            {
                bool hashSetContainsI = hashSet.Contains(i * -1);
            }*/

            DateTime finish = DateTime.Now;
            double elapsedSeconds = (finish - start).TotalSeconds;
            Console.WriteLine($"Took {elapsedSeconds:f5}s.");
        }
    }
}