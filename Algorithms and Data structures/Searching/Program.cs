using System;
using System.Globalization;

namespace Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10_000];
            array[0] = 1;

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = array[i - 1] + random.Next(minValue: 1, maxValue: 10);
                if (i % 100 == 0) array[i] += 1000;
            }

            Console.WriteLine($"First number: {array[0]}");
            Console.WriteLine($"Last number: {array[^1]}");

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commandData = input.Split();
                string commandName = commandData[0];
                int searchValue = int.Parse(commandData[1]);

                AlgorithmSummary summary = null;
                if (commandName == "linear") summary = LinearSearch(array, searchValue);
                else if (commandName == "binary") summary = BinarySearch(array, searchValue);
                else if (commandName == "tertiary") summary = TertiarySearch(array, searchValue);
                else if (commandName == "interpolation") summary = InterpolationSearch(array, searchValue);

                if (summary != null)
                {
                    Console.WriteLine("Execution summary");
                    Console.WriteLine($"-> Steps: {summary.Steps}");
                    Console.WriteLine($"-> Comparisons: {summary.Comparisons}");
                    Console.WriteLine($"-> Success: {summary.Success}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid algorithm name was provided.");
                }

                input = Console.ReadLine();
            }
        }

        private static AlgorithmSummary LinearSearch(int[] array, int searchValue)
        {
            AlgorithmSummary summary = new AlgorithmSummary();

            for (int i = 0; i < array.Length; i++)
            {
                summary.Steps++;
                summary.Comparisons++;
                if (array[i] == searchValue)
                {
                    summary.Success = true;
                    break;
                }
            }

            return summary;
        }

        private static AlgorithmSummary BinarySearch(int[] array, int searchValue)
        {
            AlgorithmSummary summary = new AlgorithmSummary();

            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                summary.Steps++;
                int middle = low + (high - low) / 2;

                summary.Comparisons++;
                if (array[middle] == searchValue)
                {
                    summary.Success = true;
                    break;
                }

                summary.Comparisons++;
                if (array[middle] > searchValue) high = middle - 1;
                else low = middle + 1;
            }

            return summary;
        }

        private static AlgorithmSummary TertiarySearch(int[] array, int searchValue)
        {
            AlgorithmSummary summary = new AlgorithmSummary();

            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                summary.Steps++;
                int offset = (high - low) / 3;
                int pivot1 = low + offset;
                int pivot2 = high - offset;

                summary.Comparisons += 2;
                if (array[pivot1] == searchValue || array[pivot2] == searchValue)
                {
                    summary.Success = true;
                    break;
                }

                summary.Comparisons++;
                if (array[pivot1] > searchValue) high = pivot1 - 1;
                else
                {
                    summary.Comparisons++;
                    if (array[pivot2] < searchValue) low = pivot2 + 1;
                    else
                    {
                        high = pivot2 - 1;
                        low = pivot1 + 1;
                    }
                }
            }

            return summary;
        }

        private static AlgorithmSummary InterpolationSearch(int[] array, int searchValue)
        {
            AlgorithmSummary summary = new AlgorithmSummary();

            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                summary.Steps++;

                summary.Comparisons++;
                if (searchValue < array[low]) break;

                summary.Comparisons++;
                if (searchValue > array[high]) break;

                int middle = low + (searchValue - array[low]) * (high - low) / (array[high] - array[low]);

                summary.Comparisons++;
                if (array[middle] == searchValue)
                {
                    summary.Success = true;
                    break;
                }

                summary.Comparisons++;
                if (array[middle] > searchValue) high = middle - 1;
                else low = middle + 1;
            }

            return summary;
        }

        private class AlgorithmSummary
        {
            public int Steps { get; set; }
            public int Comparisons { get; set; }
            public bool Success { get; set; }
        }
    }
}
