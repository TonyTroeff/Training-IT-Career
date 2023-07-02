using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    internal class BookLibrary
    {
        public BookLibrary(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public List<Book> Books { get; private set; } = new List<Book>();

        public void AddBook(string title, double rating)
        {
            Book book = new Book(title, rating);
            this.Books.Add(book);
        }

        public double AverageRating()
        {
            if (this.Books.Count == 0) return 0;
            return this.Books.Average(x => x.Rating);
        }

        public List<string> GetBooksByRating(double rating) => this.Books.Where(x => x.Rating > rating).Select(x => x.Title).ToList();

        public List<Book> SortByTitle()
        {
            this.Books = this.Books.OrderBy(x => x.Title).ToList();
            return this.Books;
        }

        public List<Book> SortByRating()
        {
            this.Books = this.Books.OrderByDescending(x => x.Rating).ToList();
            return this.Books;
        }

        public string[] ProvideInformationAboutAllBooks()
            => this.Books.Select(x => x.ToString()).ToArray();

        public bool CheckBookIsInBookLibrary(string title) => this.Books.Any(x => x.Title == title);
    }
}
