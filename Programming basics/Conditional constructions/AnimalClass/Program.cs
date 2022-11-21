using System;

namespace AnimalClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();

            if (animal == "dog") Console.WriteLine("mammal");
            else if (animal == "crocodile" || animal == "tortoise" || animal == "snake") Console.WriteLine("reptile");
            else Console.WriteLine("unknown");
        }
    }
}
