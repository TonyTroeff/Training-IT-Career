namespace Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Title #1", "Author #1");
            var book2 = new Book("Title #2", "Author #2");

            var library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);

            foreach (var book in library)
                Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }
}