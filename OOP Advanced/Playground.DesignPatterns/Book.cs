using System.Diagnostics.CodeAnalysis;

namespace Playground.DesignPatterns
{
    public class Book
    {
        // How to implement the "Static method creator" design pattern?
        private Book(string name)
        {
            this.Name = name;
        }

        private Book(string name, int rating)
            : this (name)
        {
            this.Rating = rating;
        }

        public string Name { get; }
        public int Rating { get; }

        public static Book Create(string name)
        {
            return new Book(name);
        }

        public static Book Parse(string data)
        {
            string[] bookParams = data.Split('|');
            return new Book(bookParams[0], int.Parse(bookParams[1]));
        }

        public static bool TryParse(string data, [NotNullWhen(true)] out Book? book)
        {
            book = null;
            if (string.IsNullOrWhiteSpace(data)) return false;

            string[] bookParams = data.Split('|');
            if (bookParams.Length == 0 || !int.TryParse(bookParams[1], out var rating)) return false;

            book = new Book(bookParams[0], rating);
            return true;
        }
    }
}
