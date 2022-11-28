using System;

namespace Exam2_VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vegetablePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegetableQuantity = int.Parse(Console.ReadLine());
            int fruitQuantity = int.Parse(Console.ReadLine());

            double totalPrice = vegetableQuantity * vegetablePrice + fruitQuantity * fruitPrice;
            double totalInEuros = totalPrice / 1.94;
            Console.WriteLine(totalInEuros);
        }
    }
}
