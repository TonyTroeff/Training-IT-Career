using System;

namespace CatchTheThief
{
    public class Program
    {
        public static void Main()
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            long upperBound = 0;
            if (type == "sbyte") upperBound = sbyte.MaxValue;
            else if (type == "int") upperBound = int.MaxValue;
            else if (type == "long") upperBound = long.MaxValue;

            long max = long.MinValue;
            for (int i = 0; i < n; i++)
            {
                long id = long.Parse(Console.ReadLine());

                if (id > max && id <= upperBound) max = id;
            }

            Console.WriteLine(max);
        }
    }
}