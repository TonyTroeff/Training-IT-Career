namespace MergeLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listDefinitions = Console.ReadLine().Split('|');
            List<int> numbers = new List<int>();

            for (int i = listDefinitions.Length - 1; i >= 0; i--)
            {
                int[] currentNumbers = listDefinitions[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                // numbers.AddRange(currentNumbers);
                foreach (int num in currentNumbers)
                    numbers.Add(num);
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}