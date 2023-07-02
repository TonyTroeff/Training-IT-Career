namespace Library
{
    internal class Book
    {
        public Book(string title, double rating)
        {
            this.Title = title;
            this.Rating = rating;
        }

        public string Title { get; }

        public double Rating { get; }

        public override string ToString() => $"Book {this.Title} is with {this.Rating:f1} rating.";
    }
}
