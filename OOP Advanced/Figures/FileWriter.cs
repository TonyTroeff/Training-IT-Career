using Figures.Interfaces;

namespace Figures
{
    public class FileWriter : IWriter
    {
        public string PathToFile { get; }

        public FileWriter(string pathToFile)
        {
            this.PathToFile = pathToFile;
        }

        public void WriteNewLine() => File.AppendAllText(this.PathToFile, Environment.NewLine);

        public void WriteText(char symbol) => this.WriteText(symbol.ToString());

        public void WriteText(string text) => File.AppendAllText(this.PathToFile, text);
    }
}
