using System;
using System.Collections.Generic;

namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneNumberByPerson = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split();
                string contactName = data[1];

                if (data[0] == "A")
                {
                    string phoneNumber = data[2];

                    phoneNumberByPerson[contactName] = phoneNumber;
                }
                else if (data[0] == "S")
                {
                    if (phoneNumberByPerson.ContainsKey(contactName))
                        Console.WriteLine($"{contactName} -> {phoneNumberByPerson[contactName]}");
                    else
                        Console.WriteLine($"Contact {contactName} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}