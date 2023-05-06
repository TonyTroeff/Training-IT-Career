using System;
using System.Collections.Generic;

namespace Life
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Test";
            person.Age = 4;
            Console.WriteLine(person.GetBalance());

            Dictionary<int, BankAccount> bankAccountsById = new Dictionary<int, BankAccount>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandData = command.Split();
                string commandName = commandData[0];
                int bankAccountId = int.Parse(commandData[1]);

                if (commandName == "Create")
                {
                    if (bankAccountsById.ContainsKey(bankAccountId))
                        Console.WriteLine("Account already exists");
                    else
                    {
                        BankAccount newAccount = new BankAccount();
                        newAccount.Id = bankAccountId;
                        bankAccountsById[newAccount.Id] = newAccount;
                    }
                }
                else
                {
                    if (!bankAccountsById.ContainsKey(bankAccountId))
                        Console.WriteLine("Account does not exist");
                    else
                    {
                        BankAccount requestedAccount = bankAccountsById[bankAccountId];

                        if (commandName == "Deposit")
                        {
                            double amount = double.Parse(commandData[2]);
                            requestedAccount.Deposit(amount);
                        }
                        else if (commandName == "Withdraw")
                        {
                            double amount = double.Parse(commandData[2]);
                            if (amount > requestedAccount.Balance)
                                Console.WriteLine("Insufficient balance");
                            else requestedAccount.Withdraw(amount);
                        }
                        else if (commandName == "Print")
                        {
                            Console.WriteLine(requestedAccount);
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}