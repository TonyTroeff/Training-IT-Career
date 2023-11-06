namespace CountSpecialWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isSpecial = w => char.IsUpper(w[0]);
            foreach (var word in words.Where(isSpecial))
                Console.WriteLine(word);
        }
    }
}