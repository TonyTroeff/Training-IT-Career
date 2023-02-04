using System;

namespace TourInfo
{
    public class Program
    {
        public static void Main()
        {
            string originalMetric = Console.ReadLine();
            double originalMetricValue = double.Parse(Console.ReadLine());

            string convertedMetric = "";
            double conversionRate = 0;

            if (originalMetric == "miles")
            {
                convertedMetric = "kilometers";
                conversionRate = 1.6;
            }
            else if (originalMetric == "inches")
            {
                convertedMetric = "centimeters";
                conversionRate = 2.54;
            }
            else if (originalMetric == "feet")
            {
                convertedMetric = "centimeters";
                conversionRate = 30;
            }
            else if (originalMetric == "yards")
            {
                convertedMetric = "meters";
                conversionRate = 0.91;
            }
            else if (originalMetric == "gallons")
            {
                convertedMetric = "liters";
                conversionRate = 3.8;
            }

            Console.WriteLine($"{originalMetricValue} {originalMetric} = {originalMetricValue * conversionRate:f2} {convertedMetric}");
        }
    }
}