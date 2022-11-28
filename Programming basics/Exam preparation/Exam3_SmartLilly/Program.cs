using System;

namespace Exam3_SmartLilly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int savedMoney = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0) savedMoney += (i / 2) * 10 - 1;
                else savedMoney += toyPrice;
            }

            double diff = Math.Abs(savedMoney - machinePrice);
            if (savedMoney >= machinePrice) Console.WriteLine($"Yes! {diff:f2}");
            else Console.WriteLine($"No! {diff:f2}");
        }
    }
}
