using System;

namespace CenturiesToNanoseconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            uint years = centuries * 100U;
            uint days = (uint)Math.Floor(years * 365.2422);
            uint hours = days * 24;
            uint minutes = hours * 60;
            ulong seconds = minutes * 60UL;
            ulong milliseconds = seconds * 1000;
            ulong microseconds = milliseconds * 1000;
            ulong nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}