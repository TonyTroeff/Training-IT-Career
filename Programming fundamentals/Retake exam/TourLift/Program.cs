using System;
using System.Linq;

namespace TourLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            int[] liftCabins = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int freeSeats = 0;
            for (int i = 0; i < liftCabins.Length; i++)
            {
                int originalState = liftCabins[i];
                liftCabins[i] = Math.Min(liftCabins[i] + waitingPeople, 4);

                waitingPeople -= liftCabins[i] - originalState;
                freeSeats += 4 - liftCabins[i];
            }

            if (waitingPeople == 0)
            {
                if (freeSeats > 0) Console.WriteLine("The lift has empty spots!");
            }
            else Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");

            Console.WriteLine(string.Join(' ', liftCabins));
        }
    }
}
