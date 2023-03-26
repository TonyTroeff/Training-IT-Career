using System;

namespace Beers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string bestModel = "";
            double bestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;
                if (volume > bestVolume)
                {
                    bestVolume = volume;
                    bestModel = model;
                }
            }

            Console.WriteLine(bestModel);
        }
    }
}