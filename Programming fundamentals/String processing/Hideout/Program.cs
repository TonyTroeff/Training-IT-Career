using System;

namespace Hideout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            bool isFound = false;
            while (!isFound)
            {
                string[] inputData = Console.ReadLine().Split();
                char symbolToLookFor = char.Parse(inputData[0]);
                int minimumCount = int.Parse(inputData[1]);

                int maxSequenceLength = 0, maxSequenceStart = -1;
                int index = 0;
                while (index < text.Length)
                {
                    int currentSequenceStart = index;
                    while (index < text.Length && text[index] == symbolToLookFor)
                        index++;

                    int length = index - currentSequenceStart;
                    if (length > maxSequenceLength)
                    {
                        maxSequenceLength = length;
                        maxSequenceStart = currentSequenceStart;
                    }

                    if (length <= 0) index++;
                }
                
                /*int currentSequenceLength = 0, currentSequenceStart = -1;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == symbolToLookFor)
                    {
                        currentSequenceLength++;
                        if (currentSequenceStart < 0) currentSequenceStart = i;
                    }
                    else
                    {
                        if (currentSequenceLength > maxSequenceLength)
                        {
                            maxSequenceLength = currentSequenceLength;
                            maxSequenceStart = currentSequenceStart;
                        }

                        currentSequenceLength = 0;
                        currentSequenceStart = -1;
                    }
                }

                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceStart = currentSequenceStart;
                }*/

                if (maxSequenceLength >= minimumCount)
                {
                    Console.WriteLine($"Hideout found at index {maxSequenceStart} and it is with size {maxSequenceLength}!");
                    isFound = true;
                }
            }
        }
    }
}