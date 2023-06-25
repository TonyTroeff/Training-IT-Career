using System;
using System.Linq;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Random random = new Random();

            // int[] array = new int[100];
            // for (int i = 0; i < array.Length; i++) array[i] = random.Next(minValue: 0, maxValue: 1000);

            // SelectionSort(array);
            // BubbleSort(array);
            // InsertionSort(array);
            // MergeSort(array, 0, array.Length - 1);
            // QuickSort(array, 0, array.Length - 1);
            // CountingSort(array);
            // Console.WriteLine(string.Join(", ", array));

            // Shuffle(array);
            // Console.WriteLine(string.Join(", ", array));

            SortByColumn();
        }

        static void SortByColumn()
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = parameters[0], cols = parameters[1], sortColumn = parameters[2];

            int[][] table = new int[rows][];
            for (int i = 0; i < rows; i++)
                table[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            QuickSort(table, x => x[sortColumn - 1], 0, rows - 1);

            for (int i = 0; i < rows; i++) Console.WriteLine(string.Join(' ', table[i]));
        }

        static void Swap<T>(T[] array, int index1, int index2)
        {
            if (index1 == index2) return;

            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex]) minIndex = j;
                }

                Swap(array, i, minIndex);
            }
        }

        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool swapsAreMade = false;
                for (int j = 0; j < array.Length - (i + 1); j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                        swapsAreMade = true;
                    }
                }

                if (!swapsAreMade) break;
            }
        }

        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int position = i;
                while (position > 0 && array[position - 1] > array[position])
                {
                    Swap(array, position - 1, position);
                    position--;
                }
            }
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length - 1; i++)
            {
                int swapIndex = i + random.Next(0, array.Length - i);
                Swap(array, i, swapIndex);
            }
        }

        static void MergeSort(int[] array, int start, int end)
        {
            if (start == end) return;
            if (start > end) throw new InvalidOperationException("End cannot be lower than Start");

            int middle = start + (end - start) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);

            MergeSortedIntervals(array, start, middle, middle + 1, end);
        }

        static void MergeSortedIntervals(int[] array, int start1, int end1, int start2, int end2)
        {
            if (start1 > end1) throw new InvalidOperationException("End cannot be lower than Start (section 1)");
            if (start2 > end2) throw new InvalidOperationException("End cannot be lower than Start (section 2)");

            int length1 = end1 - start1 + 1, length2 = end2 - start2 + 1;
            int[] result = new int[length1 + length2];

            int firstIndex = start1, secondIndex = start2, resultIndex = 0;
            while (firstIndex <= end1 || secondIndex <= end2)
            {
                int firstNumber = firstIndex <= end1 ? array[firstIndex] : int.MaxValue;
                int secondNumber = secondIndex <= end2 ? array[secondIndex] : int.MaxValue;

                int nextNumber;
                if (firstNumber <= secondNumber) nextNumber = array[firstIndex++];
                else nextNumber = array[secondIndex++];

                result[resultIndex] = nextNumber;
                resultIndex++;
            }

            for (int i = 0; i < length1; i++)
                array[start1 + i] = result[i];
            for (int i = 0; i < length2; i++)
                array[start2 + i] = result[length1 + i];
        }

        static void QuickSort<TElement, TValue>(TElement[] array, Func<TElement, TValue> valueFunc, int start, int end)
            where TValue : IComparable<TValue>
        {
            if (start >= end) return;

            TElement pivot = array[start];
            TValue pivotValue = valueFunc(pivot);

            int lowerElements = 0;
            for (int i = start + 1; i <= end; i++)
            {
                if (valueFunc(array[i]).CompareTo(pivotValue) < 0)
                {
                    Swap(array, i, start + lowerElements + 1);
                    lowerElements++;
                }
            }

            int finalPivotPosition = start + lowerElements;
            Swap(array, start, finalPivotPosition);
            QuickSort(array, valueFunc, start, finalPivotPosition - 1);
            QuickSort(array, valueFunc, finalPivotPosition + 1, end);
        }

        static void QuickSort(int[] array, int start, int end)
            => QuickSort(array, i => i, start, end);

        static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;

            int min = array[0], max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                min = Math.Min(min, array[i]);
                max = Math.Max(max, array[i]);
            }

            int[] counts = new int[max - min + 1];
            for (int i = 0; i < array.Length; i++)
                counts[array[i] - min]++;

            int resultIndex = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                for (int j = 0; j < counts[i]; j++)
                    array[resultIndex++] = min + i;
            }
        }
    }
}
