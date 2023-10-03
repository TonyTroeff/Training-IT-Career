using System.Collections;

namespace Books
{
    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            if (book is null) return;

            this._books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            // First approach: manually iterate over the collection
            // foreach (Book book in this._books)
            //     yield return book;

            // Second approach: use the enumerator of the collection
            return this._books.GetEnumerator();
        }

        // This is called "explicit implementation":
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
