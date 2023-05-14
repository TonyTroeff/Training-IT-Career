using System;

namespace StaticVsNonStatic
{
    internal class Book
    {
        public static string IsbnPrefix { get; set; }

        public string Name { get; set; }

        public void SaySomethingInstance()
        {
            Console.WriteLine("The non-static method has been invoked.");
            SaySomethingStatic();
        }

        public static void SaySomethingStatic()
        {
            Console.WriteLine("The static method has been invoked.");
        }
    }
}
