using Playground.Reflection.Interfaces;

namespace Playground.Reflection
{
    public class ConsoleWriter : IWriter
    {
        public void WriteNewLine() => Console.WriteLine();

        public void WriteText(string? text)
        {
            if (!string.IsNullOrWhiteSpace(text)) Console.Write(text);
        }
    }
}
