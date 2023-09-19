namespace SwapElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>(capacity: n);

            for (int i = 0; i < n; i++)
            {
                string currentInput = Console.ReadLine();
                words.Add(currentInput);
            }

            int[] swapArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(words, swapArgs[0], swapArgs[1]);

            Console.WriteLine(string.Join(", ", words));
        }

        static void Swap<T>(List<T> list, int position1, int position2)
        {
            T temp = list[position1];
            list[position1] = list[position2];
            list[position2] = temp;
        }
    }
}