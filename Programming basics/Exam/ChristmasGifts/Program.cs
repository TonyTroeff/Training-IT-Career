using System;

namespace ChristmasGifts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int lego = 0, monopoly = 0, puzzle = 0, robot = 0;
            for (int i = 0; i < n; i++)
            {
                string gift = Console.ReadLine();
                if (gift == "lego") lego++;
                else if (gift == "monopoly") monopoly++;
                else if (gift == "puzzle") puzzle++;
                else if (gift == "robot") robot++;
            }

            Console.WriteLine($"Lego: {lego}");
            Console.WriteLine($"Monopoly: {monopoly}");
            Console.WriteLine($"Puzzles: {puzzle}");
            Console.WriteLine($"Robots: {robot}");
        }
    }
}
