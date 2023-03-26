using System;

namespace BoatsSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            bool moveFirst = true;

            int firstPosition = 0, secondPosition = 0;
            for (int i = 0; i < n && firstPosition < 50 && secondPosition < 50; i++)
            {
                string input = Console.ReadLine();
                if (input == "UPGRADE")
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat + 3);
                }
                else
                {
                    if (moveFirst) firstPosition += input.Length;
                    else secondPosition += input.Length;
                }

                moveFirst = !moveFirst;
            }

            if (firstPosition > secondPosition) Console.WriteLine(firstBoat);
            else Console.WriteLine(secondBoat);
        }
    }
}