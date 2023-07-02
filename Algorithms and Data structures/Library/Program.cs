using System;
using System.Collections.Generic;

namespace Library
{
    internal class Program
    {
        static BookLibrary bookLibrary = new BookLibrary("BookLibrary");
        static void Main(string[] args)
        {
            string line;

            while ("END" != (line = Console.ReadLine()))
            {
                string[] cmdArgs = line.Split(',');

                switch (cmdArgs[0])
                {
                    case "AddBook":
                        AddBook(cmdArgs[1], double.Parse(cmdArgs[2]));
                        break;
                    case "AverageRating":
                        AverageRating();
                        break;
                    case "GetBestBooksByRating":
                        GetBooksByRating(double.Parse(cmdArgs[1]));
                        break;
                    case "SortByTitle":
                        SortByTitle();
                        break;
                    case "SortByRating":
                        SortByRating();
                        break;
                    case "CheckBook":
                        CheckBookIsInBookLibrary(cmdArgs[1]);
                        break;
                    case "PrintBookLibraryInfo":
                        ProvideInformationAboutAllBooks();
                        break;
                }
            }
        }

        private static void ProvideInformationAboutAllBooks()
        {
            string[] info = bookLibrary.ProvideInformationAboutAllBooks();
            foreach (string item in info)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckBookIsInBookLibrary(string title)
        {
            if (bookLibrary.CheckBookIsInBookLibrary(title))
            {
                Console.WriteLine($"Book {title} is available.");
            }
            else
            {
                Console.WriteLine($"Book {title} is not available.");
            }
        }
        private static void SortByRating()
        {
            bookLibrary.SortByRating();
            Console.WriteLine("The worst book is with rating: " + bookLibrary.Books[bookLibrary.Books.Count - 1].Rating);
        }
        private static void SortByTitle()
        {
            bookLibrary.SortByTitle();
            Console.WriteLine("First book is: " + bookLibrary.Books[0].Title);
        }
        private static void GetBooksByRating(double rating)
        {
            List<string> bestBooks = bookLibrary.GetBooksByRating(rating);
            Console.WriteLine("Most rated books are: " + string.Join(", ", bestBooks));
        }

        private static void AverageRating()
        {
            double averageRating = bookLibrary.AverageRating();
            Console.WriteLine($"Average rating of books: {averageRating:f1}");
        }

        private static void AddBook(string title, double rating)
        {
            bookLibrary.AddBook(title, rating);
            Console.WriteLine($"Added book: {title} -> {rating}.");
        }
    }
}
