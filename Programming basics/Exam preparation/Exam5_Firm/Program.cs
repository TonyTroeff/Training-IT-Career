using System;

namespace Exam5_Firm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            int availableHours = (int)Math.Floor(days * 8 * 0.9 + workers * days * 2);
            if (availableHours >= hours) Console.WriteLine($"Yes!{availableHours - hours} hours left.");
            else Console.WriteLine($"Not enough time!{hours - availableHours} hours needed.");
        }
    }
}
