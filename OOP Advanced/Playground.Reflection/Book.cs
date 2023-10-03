namespace Playground.Reflection
{
    public class Book
    {
        public string Name { get; }
        public string ISBN { get; }

        public Book(string name, string isbn)
        {
            this.Name = name;
            this.ISBN = isbn;
        }

        public override string ToString() => $"This is a book, called {this.Name} with ISBN {this.ISBN}.";
    }
}
