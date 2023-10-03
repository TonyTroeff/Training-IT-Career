namespace Figures.Interfaces
{
    public interface IWriter
    {
        void WriteText(char symbol);
        void WriteText(string text);
        void WriteNewLine();
    }
}
