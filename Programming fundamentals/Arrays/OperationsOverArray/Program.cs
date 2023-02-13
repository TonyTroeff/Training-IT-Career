using System;
using System.Linq;

namespace OperationsOverArray
{
    public class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandInput = Console.ReadLine().Split();
                string commandName = commandInput[0];

                if (commandName == "Distinct")
                    words = words.Distinct().ToArray();
                else if (commandName == "Reverse")
                    Array.Reverse(words);
                else if (commandName == "Replace") 
                {
                    int index = int.Parse(commandInput[1]);
                    string newValue = commandInput[2];

                    words[index] = newValue;
                }
            }

            Console.WriteLine(string.Join(", ", words));
        }
    }
}