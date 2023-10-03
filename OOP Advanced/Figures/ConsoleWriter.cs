using Figures.Interfaces;

namespace Figures
{
    public class ConsoleWriter : IWriter
    {
        public void WriteNewLine() => Console.WriteLine();

        public void WriteText(char symbol) => Console.Write(symbol);

        public void WriteText(string text) => Console.Write(text);
    }
}
