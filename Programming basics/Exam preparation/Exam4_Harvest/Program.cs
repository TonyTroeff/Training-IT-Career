using System;

namespace Exam4_Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapesPerSquareMeter = double.Parse(Console.ReadLine());
            int requiredLitersOfWine = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());

            double totalGrapes = grapesPerSquareMeter * area * 0.4;
            double producedLitersOfWine = totalGrapes / 2.5; 

            double diff = producedLitersOfWine - requiredLitersOfWine;
            if (diff < 0)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(-1 * diff)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(producedLitersOfWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(diff)} liters left -> {Math.Ceiling(diff / workersCount)} liters per person.");
            }
        }
    }
}
