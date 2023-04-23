using System;
using System.Collections.Generic;
using System.Linq;

namespace VetClinicVisitors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> visitors = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();
            while (command != "END OF OWNERS")
            {
                if (command == "Remove last owner") visitors.RemoveAt(visitors.Count - 1);
                else if (command == "Remove first owner") visitors.RemoveAt(0);
                else if (command == "Remove owner on position")
                {
                    int position = int.Parse(Console.ReadLine());
                    visitors.RemoveAt(position);
                }
                else if (command == "Add owner on position")
                {
                    string owner = Console.ReadLine();
                    int position = int.Parse(Console.ReadLine());
                    visitors.Insert(position, owner);
                }
                else if (command == "Add owner")
                {
                    string owner = Console.ReadLine();
                    visitors.Add(owner);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', visitors));
        }
    }
}