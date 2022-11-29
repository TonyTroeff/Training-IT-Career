using System;

namespace Afternoon_Exchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollars = double.Parse(Console.ReadLine());
            double convertRate = double.Parse(Console.ReadLine());
            int satoshiPerByte = int.Parse(Console.ReadLine());

            double availableBitcoins = dollars / convertRate;
            double tax = availableBitcoins * (satoshiPerByte * 1024) / 100000000;
            double taxInDollars = tax * convertRate;

            double boughtBitcoins = availableBitcoins - tax;
            double programmerPayment = boughtBitcoins * 0.1;

            double totalIncome = boughtBitcoins - programmerPayment;
                
            Console.WriteLine($"Total bitcoin after expenses: {totalIncome:f5} BTC");
            Console.WriteLine($"Tax payed: {taxInDollars:f2} USD");
            Console.WriteLine($"Programmer's payment: {programmerPayment:f5} BTC");
        }
    }
}
