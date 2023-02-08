using System;

namespace StringAndObjectVariables
{
    public class Program
    {
        public static void Main()
        {
            string text1 = Console.ReadLine();
            string text2 = Console.ReadLine();

            object object1 = text1 + ' ' + text2;
            string text3 = (string)object1;
            Console.WriteLine(text3);
        }
    }
}