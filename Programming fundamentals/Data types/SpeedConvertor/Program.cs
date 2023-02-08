using System;

namespace SpeedConvertor
{
    public class Program
    {
        public static void Main()
        {
            float meters = float.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int totalSeconds = hours * 3600 + minutes * 60 + seconds;

            double speedInMS = meters / (double)totalSeconds;
            double speedInKmH = speedInMS * 3.6;
            double speedInMiH = speedInKmH / 1.609;
            Console.WriteLine(speedInMS);
            Console.WriteLine(speedInKmH);
            Console.WriteLine(speedInMiH);
        }
    }
}