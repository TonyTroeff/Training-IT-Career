using System;
using System.Collections.Generic;

namespace BrowserHistory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string input = Console.ReadLine();
            while (input != "exit")
            {
                if (input == "back")
                {
                    if (stack.Count == 0) Console.WriteLine("Cannot go back - stack is empty.");
                    else stack.Pop();
                }
                else stack.Push(input);

                PrintBrowsingHistoryInfo(stack);

                input = Console.ReadLine();
            }

            PrintBrowsingHistoryInfo(stack);
        }

        private static void PrintBrowsingHistoryInfo(Stack<string> stack)
        {
            if (stack.Count == 0) Console.WriteLine("No browsing history.");
            else
            {
                Console.WriteLine($"History entries count: {stack.Count}");
                Console.WriteLine($"Current website: {stack.Peek()}");
            }
        }
    }
}
