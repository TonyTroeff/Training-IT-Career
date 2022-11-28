using System;

namespace Exam5_Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workDays = int.Parse(Console.ReadLine());
            double wagePerDay = double.Parse(Console.ReadLine());
            double dollarRate = double.Parse(Console.ReadLine());

            double monthlyWage = workDays * wagePerDay;
            double incomePerYear = 14.5 * monthlyWage;
            double taxes = 0.25 * incomePerYear;

            double netIncome = (incomePerYear - taxes) * dollarRate;
            double incomePerDay = netIncome / 365;
            Console.WriteLine($"{incomePerDay:f2}");
        }
    }
}
