using System;

namespace CashReceipt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            PrintRowOfDashes();
            PrintBody();
            PrintRowOfDashes();
            PrintBottom();
        }

        static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
        }

        static void PrintBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        static void PrintBottom()
        {
            Console.WriteLine("© SoftUni");
        }

        static void PrintRowOfDashes()
        {
            Console.WriteLine("------------------------------");
        }
    }
}
