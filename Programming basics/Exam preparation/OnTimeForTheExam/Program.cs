using System;

namespace OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());

            int arrivalHours = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examMinutesSinceMidnight = examHours * 60 + examMinutes;
            int arrivalMinutesSinceMidnight = arrivalHours * 60 + arrivalMinutes;

            int diff = Math.Abs(examMinutesSinceMidnight - arrivalMinutesSinceMidnight);
            int diffHours = diff / 60;
            int diffMinutes = diff % 60;

            string timeDisplay;
            if (diffHours > 0)
            {
                if (diffMinutes < 10) timeDisplay = $"{diffHours}:0{diffMinutes} hours";
                else timeDisplay = $"{diffHours}:{diffMinutes} hours";
            }
            else timeDisplay = $"{diffMinutes} minutes";

            string keyword;
            if (examMinutesSinceMidnight > arrivalMinutesSinceMidnight)
            {
                if (diff <= 30) Console.WriteLine("On time");
                else Console.WriteLine("Early");

                keyword = "before";
            }
            else
            {
                Console.WriteLine("Late");
                keyword = "after";
            }

            if (diff != 0) Console.WriteLine($"{timeDisplay} {keyword} the start");
        }
    }
}
