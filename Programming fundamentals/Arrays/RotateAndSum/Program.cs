using System;
using System.Linq;

namespace RotateAndSum
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int[] sum = new int[numbers.Length];
            for (int i = 0; i < rotations; i++)
            {
                Rotate(numbers);

                for (int j = 0; j < numbers.Length; j++)
                    sum[j] += numbers[j];
            }

            Console.WriteLine(string.Join(" ", sum));
        }

        static void Rotate(int[] array)
        {
            int lastElement = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
                array[i] = array[i - 1];
            
            array[0] = lastElement;
        }
    }
}