using System;
using System.Collections;

namespace Stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedStack stack = new CustomLinkedStack();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
                Console.WriteLine($"Top element is: {stack.Peek()}");
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Removed element {stack.Pop()}");
            }

            for (int i = 0; i < 5; i++)
            {
                stack.Push(5 + i);
                Console.WriteLine($"Top element is: {stack.Peek()}");
            }
        }
    }
}
