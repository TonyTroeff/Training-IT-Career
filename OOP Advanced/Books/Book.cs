using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
