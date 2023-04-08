using System;
using System.Collections.Generic;
using System.Linq;

namespace LogsAggregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> sessionLengthByUser = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> ipAddressesByUser = new Dictionary<string, HashSet<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string ipAddress = input[0], user = input[1];
                int sessionLength = int.Parse(input[2]);

                if (!sessionLengthByUser.ContainsKey(user))
                {
                    sessionLengthByUser[user] = 0;
                    ipAddressesByUser[user] = new HashSet<string>();
                }

                sessionLengthByUser[user] += sessionLength;
                ipAddressesByUser[user].Add(ipAddress);
            }

            foreach (var (user, sessionLength) in sessionLengthByUser.OrderBy(x => x.Key))
            {
                HashSet<string> ipAddresses = ipAddressesByUser[user];
                string ipAddressesInfo = string.Join(", ", ipAddresses.OrderBy(x => x));
                Console.WriteLine($"{user}: {sessionLength} [{ipAddressesInfo}]");
            }
        }
    }
}