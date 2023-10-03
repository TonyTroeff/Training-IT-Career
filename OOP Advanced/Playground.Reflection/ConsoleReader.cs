using Playground.Reflection.Interfaces;

namespace Playground.Reflection
{
    public class ConsoleReader : IReader
    {
        public int ReadNumber(string informationText)
        {
            string input;
            int result;
            do
            {
                if (!string.IsNullOrWhiteSpace(informationText)) Console.Write(informationText);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out result));

            return result;
        }

        public string ReadString(string informationText)
        {
            string input;
            do
            {
                if (!string.IsNullOrWhiteSpace(informationText)) Console.Write(informationText);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}
