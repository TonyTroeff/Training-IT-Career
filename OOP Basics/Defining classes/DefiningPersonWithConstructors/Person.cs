using System.Collections.Generic;
using System.Linq;

namespace DefiningPersonWithConstructors
{
    public class Person
    {
        public Person()
            : this(1)
        {
        }

        public Person(int age)
            : this("No name", age)
        {
        }

        public Person(string name, int age)
            : this(name, age, new List<BankAccount>(capacity: 0))
        {
        }

        public Person(string name, int age, List<BankAccount> accounts)
        {
            this.Name = name;
            this.Age = age;
            this.Accounts = accounts;
        }

        public string Name { get; }
        public int Age { get; }
        public List<BankAccount> Accounts { get; }

        public double GetBalance() => this.Accounts.Sum(a => a.Balance);
    }
}
