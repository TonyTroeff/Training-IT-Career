using System;
using System.Text;

namespace SecretMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] commandData = command.Split(":|:");
                string commandName = commandData[0];

                bool printMessage = true;
                if (commandName == "InsertSpace")
                {
                    int index = int.Parse(commandData[1]);
                    message = message.Insert(index, " ");
                }
                else if (commandName == "Reverse")
                {
                    string substring = commandData[1];

                    int index = message.IndexOf(substring);
                    if (index == -1)
                    {
                        printMessage = false;
                        Console.WriteLine("error");
                    }
                    else message = message.Remove(index, substring.Length) + Reverse(substring);
                }
                else if (commandName == "ChangeAll")
                {
                    string substring = commandData[1];
                    string replacement = commandData[2];

                    message = message.Replace(substring, replacement);
                }

                if (printMessage) Console.WriteLine(message);
                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        static string Reverse(string s)
        {
            StringBuilder stringBuilder = new StringBuilder(capacity: s.Length);
            for (int i = s.Length - 1; i >= 0; i--) stringBuilder.Append(s[i]);

            return stringBuilder.ToString();
        }
    }
}