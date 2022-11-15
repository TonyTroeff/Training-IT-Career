using System;
using System.Globalization;

namespace _1000Days
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string DateFormat = "dd-MM-yyyy";
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, DateFormat, CultureInfo.InvariantCulture);
            DateTime result = date.AddDays(999);

            Console.WriteLine(result.ToString(DateFormat));
        }
    }
}
