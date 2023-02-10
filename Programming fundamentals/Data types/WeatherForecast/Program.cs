using System;

namespace WeatherForecast
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (sbyte.TryParse(input, out _)) Console.WriteLine("Sunny");
            else if (int.TryParse(input, out _)) Console.WriteLine("Cloudy");
            else if (long.TryParse(input, out _)) Console.WriteLine("Windy");
            else Console.WriteLine("Rainy");
        }
    }
}