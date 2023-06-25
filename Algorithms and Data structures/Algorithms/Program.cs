using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    internal class Program
    {
        static void Main()
        {
            //int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int number = int.Parse(Console.ReadLine());

            //if (BinarySearch(array, number)) Console.WriteLine($"{number} exists in the list.");
            //else Console.WriteLine($"{number} does not exist in the list.");

            //int insertPosition = BinarySearchRightmostInsertPosition(array, number);
            //Console.WriteLine($"{number} should be inserted at position {insertPosition}");

            //int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int[] concatenation = MergeOrderedArrays(firstArray, secondArray);
            //Console.WriteLine(string.Join(", ", concatenation));

            int[] arrayToReverse = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] reversedArray = ReverseUsingStack(arrayToReverse);
            Console.WriteLine(string.Join(", ", reversedArray));
        }

        static bool Contains(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) return true;
            }

            return false;
        }

        static bool BinarySearch(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] == number) return true;

                if (array[middle] > number) high = middle - 1;
                else low = middle + 1;
            }

            return false;
        }

        static int BinarySearchInsertPosition(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] == number) return middle;

                if (array[middle] > number) high = middle - 1;
                else low = middle + 1;
            }

            return low;
        }

        static int BinarySearchLeftmostInsertPosition(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] >= number) high = middle - 1;
                else low = middle + 1;
            }

            return low;
        }

        static int BinarySearchRightmostInsertPosition(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] > number) high = middle - 1;
                else low = middle + 1;
            }

            return high;
        }

        static int[] MergeOrderedArrays(int[] first, int[] second)
        {
            int[] result = new int[first.Length + second.Length];

            int firstIndex = 0, secondIndex = 0;
            while (firstIndex < first.Length || secondIndex < second.Length)
            {
                int firstNumber = firstIndex < first.Length ? first[firstIndex] : int.MaxValue;
                int secondNumber = secondIndex < second.Length ? second[secondIndex] : int.MaxValue;

                int nextNumber;
                if (firstNumber <= secondNumber) nextNumber = first[firstIndex++];
                else nextNumber = second[secondIndex++];

                result[firstIndex + secondIndex - 1] = nextNumber;
            }

            return result;
        }

        static int[] ReverseUsingStack(int[] arr)
        {
            Stack<int> stack = new Stack<int>(capacity: arr.Length);
            for (int i = 0; i < arr.Length; i++) stack.Push(arr[i]);

            int[] result = new int[arr.Length];
            while (stack.Count > 0) result[result.Length - stack.Count] = stack.Pop();

            return result;
        }
    }
}
