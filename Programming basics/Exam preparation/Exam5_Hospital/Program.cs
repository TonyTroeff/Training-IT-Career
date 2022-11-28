using System;

namespace Exam5_Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int doctors = 7;
            int treatedPatients = 0, untreatedPatients = 0;
            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0 && (untreatedPatients > treatedPatients)) doctors++;

                int patients = int.Parse(Console.ReadLine());
                if (patients <= doctors) treatedPatients += patients;
                else
                {
                    treatedPatients += doctors;
                    untreatedPatients += patients - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
