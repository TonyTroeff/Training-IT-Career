using System;

namespace AnonymousDownsite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            string[] websites = new string[n];
            decimal totalLoss = 0;

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string websiteName = inputData[0];
                int visits = int.Parse(inputData[1]);
                decimal commercialPricePerVisit = decimal.Parse(inputData[2]);

                websites[i] = websiteName;
                totalLoss += visits * commercialPricePerVisit;
            }

            for (int i = 0; i < n; i++) Console.WriteLine(websites[i]);
            Console.WriteLine($"Total Loss: {totalLoss:f20}");

            long poweredSecurityKey = 1;
            for (int i = 0; i < n; i++) poweredSecurityKey *= securityKey;
            Console.WriteLine($"Security Token: {poweredSecurityKey}");
            // Console.WriteLine($"Security Token: {Math.Pow(securityKey, n)}");
        }
    }
}