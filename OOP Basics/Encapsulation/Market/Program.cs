using System;
using System.Collections.Generic;
using System.Linq;

namespace Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] peopleData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, Person> peopleByName = new Dictionary<string, Person>();

                foreach (string personData in peopleData)
                {
                    string[] parameters = personData.Split('=');
                    Person person = new Person(parameters[0], decimal.Parse(parameters[1]));
                    peopleByName[person.Name] = person;
                }

                string[] productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, Product> productsByName = new Dictionary<string, Product>();

                foreach (string productData in productsData)
                {
                    string[] parameters = productData.Split('=');
                    Product product = new Product(parameters[0], decimal.Parse(parameters[1]));
                    productsByName[product.Name] = product;
                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] commandData = command.Split();
                    string personName = commandData[0], productName = commandData[1];

                    if (peopleByName[personName].Buy(productsByName[productName]))
                        Console.WriteLine($"{personName} bought {productName}");
                    else
                        Console.WriteLine($"{personName} can't afford {productName}");

                    command = Console.ReadLine();
                }

                foreach (var person in peopleByName.Values)
                {
                    if (person.Bag.Count == 0)
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    else Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag.Select(p => p.Name))}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}