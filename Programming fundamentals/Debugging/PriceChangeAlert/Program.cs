using System;

namespace PriceChangeAlert
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double significanceBound = double.Parse(Console.ReadLine());
            double lastPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());
                
                double percentageOfDifference = CalculatePercentageOfDifference(lastPrice, currentPrice);
                bool isSignificantDifference = IsSignificant(percentageOfDifference, significanceBound);

                string message = GetMessage(currentPrice, lastPrice, percentageOfDifference, isSignificantDifference);
                Console.WriteLine(message);

                lastPrice = currentPrice;
            }
        }

        private static string GetMessage(double currentPrice, double lastPrice, double difference, bool isSignificant)
        {
            string resultMessage = "";
            if (difference == 0)
                resultMessage = $"NO CHANGE: {currentPrice}";
            else if (!isSignificant)
                resultMessage = $"MINOR CHANGE: {lastPrice} to {currentPrice} ({difference:F2}%)";
            else if (isSignificant && difference > 0)
                resultMessage = $"PRICE UP: {lastPrice} to {currentPrice} ({difference:F2}%)";
            else if (isSignificant && difference < 0)
                resultMessage = $"PRICE DOWN: {lastPrice} to {currentPrice} ({difference:F2}%)";

            return resultMessage;
        }

        private static bool IsSignificant(double significanceBound, double difference)
        {
            return Math.Abs(significanceBound) >= difference;
        }

        private static double CalculatePercentageOfDifference(double lastPrice, double currentPrice)
        {
            return (currentPrice - lastPrice) / lastPrice;
        }
    }
}