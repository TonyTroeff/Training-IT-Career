using System;

namespace Exam4_BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double heritage = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            double requiredMoney = 0;
            for (int i = 1800; i <= year; i++)
            {
                requiredMoney += 12000;
                if (i % 2 != 0) requiredMoney += 50 * (18 + i - 1800);
            }

            if (requiredMoney > heritage) Console.WriteLine($"He will need {requiredMoney - heritage:f2} dollars to survive.");
            else Console.WriteLine($"Yes! He will live a carefree life and will have {heritage - requiredMoney:f2} dollars left.");
        }
    }
}
