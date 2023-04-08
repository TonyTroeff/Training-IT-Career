using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();
            while (command != "3:1")
            {
                string[] commandData = command.Split();
                string commandName = commandData[0];

                if (commandName == "merge")
                {
                    int startIndex = Math.Max(int.Parse(commandData[1]), 0);
                    int endIndex = Math.Min(int.Parse(commandData[2]), words.Count - 1);

                    if (startIndex < endIndex)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = startIndex; i <= endIndex; i++) sb.Append(words[i]);

                        for (int i = endIndex; i >= startIndex; i--) words.RemoveAt(i);
                        words.Insert(startIndex, sb.ToString());
                    }
                }
                else if (commandName == "divide")
                {
                    int index = int.Parse(commandData[1]);
                    int partitions = int.Parse(commandData[2]);

                    string elementToDivide = words[index];
                    words.RemoveAt(index);

                    int partitionLength = elementToDivide.Length / partitions;

                    StringBuilder sb = new StringBuilder();

                    int partitionNumber = 1;
                    for (int i = 0; i < elementToDivide.Length; i++)
                    {
                        sb.Append(elementToDivide[i]);
                        if ((partitionNumber < partitions && sb.Length == partitionLength)
                            || i == elementToDivide.Length - 1)
                        {
                            words.Insert(index + partitionNumber - 1, sb.ToString());
                            sb.Clear();
                            partitionNumber++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}