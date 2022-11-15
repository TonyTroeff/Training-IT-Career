using System;

namespace ConvertMoney
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal inputMoney = decimal.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();

            decimal bgnMoney = 0;
            if (inputCurrency == "BGN") bgnMoney = inputMoney;
            else if (inputCurrency == "USD") bgnMoney = inputMoney * 1.79549m;
            else if (inputCurrency == "EUR") bgnMoney = inputMoney * 1.95583m;
            else if (inputCurrency == "GBP") bgnMoney = inputMoney * 2.53405m;

            decimal result = 0;
            if (outputCurrency == "BGN") result = bgnMoney;
            else if (outputCurrency == "USD") result = bgnMoney / 1.79549m;
            else if (outputCurrency == "EUR") result = bgnMoney / 1.95583m;
            else if (outputCurrency == "GBP") result = bgnMoney / 2.53405m;

            Console.WriteLine($"{Math.Round(result, 2)} {outputCurrency}");
        }
    }
}
