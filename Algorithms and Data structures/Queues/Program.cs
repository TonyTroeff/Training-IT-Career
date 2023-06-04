using System;

namespace Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new CustomQueue();

            for (int i = 1; i <= 7; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Added element {i}");
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"The top element is: {queue.Peek()}");
                int removedElement = queue.Dequeue();
                Console.WriteLine($"Removed element {removedElement}");
            }

            for (int i = 8; i <= 13; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Added element {i}");
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"The top element is: {queue.Peek()}");
                int removedElement = queue.Dequeue();
                Console.WriteLine($"Removed element {removedElement}");
            }


            Console.WriteLine(queue.Count);
        }
    }
}
