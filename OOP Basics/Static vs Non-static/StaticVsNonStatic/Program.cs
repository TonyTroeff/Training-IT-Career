using System;
using System.Collections.Generic;

namespace StaticVsNonStatic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();
            list.Insert(0, 13);

            Book.SaySomethingStatic();
            string isbnPrefix = Book.IsbnPrefix;

            Book bookInstance1 = new Book();
            bookInstance1.SaySomethingInstance();

            Book bookInstance2 = new Book();
            bookInstance2.SaySomethingInstance();

            Book generatedBookInstance1 = StaticBookGenerator.GenerateBook();
        }
    }
}
