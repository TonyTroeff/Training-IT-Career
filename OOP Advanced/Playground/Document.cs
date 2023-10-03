namespace Playground
{
    public class Document : IPrintable
    {
        public string Name { get; }

        public Document(string name)
        {
            this.Name = name;
        }

        public string Print()
        {
            return $"This is a document: {this.Name}";
        }
    }
}
