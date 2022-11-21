using System;

namespace UnitConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inputMetricValue = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();

            double valueInMeters = 0;
            if (inputMetric == "mm") valueInMeters = inputMetricValue / 1000;
            else if (inputMetric == "cm") valueInMeters = inputMetricValue / 100;
            else if (inputMetric == "mi") valueInMeters = inputMetricValue / 0.000621371192;
            else if (inputMetric == "in") valueInMeters = inputMetricValue / 39.3700787;
            else if (inputMetric == "km") valueInMeters = inputMetricValue / 0.001;
            else if (inputMetric == "ft") valueInMeters = inputMetricValue / 3.2808399;
            else if (inputMetric == "yd") valueInMeters = inputMetricValue / 1.0936133;
            else if (inputMetric == "m") valueInMeters = inputMetricValue;

            double outputMetricValue = 0;
            if (outputMetric == "mm") outputMetricValue = valueInMeters * 1000;
            else if (outputMetric == "cm") outputMetricValue = valueInMeters * 100;
            else if (outputMetric == "mi") outputMetricValue = valueInMeters * 0.000621371192;
            else if (outputMetric == "in") outputMetricValue = valueInMeters * 39.3700787;
            else if (outputMetric == "km") outputMetricValue = valueInMeters * 0.001;
            else if (outputMetric == "ft") outputMetricValue = valueInMeters * 3.2808399;
            else if (outputMetric == "yd") outputMetricValue = valueInMeters * 1.0936133;
            else if (outputMetric == "m") outputMetricValue = valueInMeters;

            Console.WriteLine($"{outputMetricValue} {outputMetric}");
        }
    }
}
