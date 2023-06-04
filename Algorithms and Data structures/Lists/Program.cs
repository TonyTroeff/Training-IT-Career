using System;
using System.Collections.Generic;

namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList list = new CustomDoublyLinkedList();

            for (int i = 0; i < 10; i++) list.Add(i);

            Console.WriteLine(list.Count);

            for (int i = 0; i < 10; i++) list[i] += 5;

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Inserting element at index {i}");
                list.Insert(i, i * 2);
            }

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"Value at index {i}: {list[i]}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Removing element at index {0}");
                list.RemoveAt(0);

                Console.WriteLine($"Removing element at index {list.Count / 2}");
                list.RemoveAt(list.Count / 2);

                Console.WriteLine($"Removing element at index {list.Count - 1}");
                list.RemoveAt(list.Count - 1);
            }

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"Value at index {i}: {list[i]}");

            // IEnumerable
            Console.WriteLine(string.Join(", ", list));

            //int elementsCount = list.Count;
            //for (int i = 0; i < elementsCount; i++) list.RemoveAt(0);

            //Console.WriteLine($"List has {list.Count} elements left.");


            // For tomorrow:
            // - Use in loops
            // - Try doubly linked nodes
        }
    }
}
