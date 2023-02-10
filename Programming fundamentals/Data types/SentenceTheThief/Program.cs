using System;

namespace SentenceTheThief
{
    public class Program
    {
        public static void Main()
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            long upperBound = 0;
            if (type == "sbyte") upperBound = sbyte.MaxValue;
            else if (type == "int") upperBound = int.MaxValue;
            else if (type == "long") upperBound = long.MaxValue;

            long max = long.MinValue;
            for (int i = 0; i < n; i++)
            {
                long id = long.Parse(Console.ReadLine());

                if (id > max && id <= upperBound) max = id;
            }

            sbyte sentenceTerm;
            if (max < 0) sentenceTerm = sbyte.MinValue;
            else sentenceTerm = sbyte.MaxValue;
            
            long sentence = max / sentenceTerm;
            if (max % sentenceTerm != 0) sentence++;

            string yearsWord = sentence == 1 ? "year" : "years";
            Console.WriteLine($"Prisoner with id {max} is sentenced to {sentence} {yearsWord}");
        }
    }
}