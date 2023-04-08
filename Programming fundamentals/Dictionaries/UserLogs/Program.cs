using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> ipAddressesByUser = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputData = input.Split();
                string[] ipAddressData = inputData[0].Split('=');
                string[] usernameData = inputData[2].Split('=');

                string ipAddress = ipAddressData[1];
                string username = usernameData[1];

                if (!ipAddressesByUser.ContainsKey(username))
                    ipAddressesByUser[username] = new Dictionary<string, int>();
                if (!ipAddressesByUser[username].ContainsKey(ipAddress))
                    ipAddressesByUser[username][ipAddress] = 0;

                ipAddressesByUser[username][ipAddress]++;

                input = Console.ReadLine();
            }

            foreach (var (user, ipAddresses) in ipAddressesByUser.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user}:");

                string[] ipAddressesInfo = ipAddresses
                    .OrderByDescending(x => x.Value)
                    .Select(x => $"{x.Key} => {x.Value}")
                    .ToArray();

                Console.WriteLine($"{string.Join(", ", ipAddressesInfo)}.");
            }
        }
    }
}