using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Person
    {
        // Stage 1 (fields + methods)
        /*private string _name;
        private int _age;

        public string GetName() => this._name;
        public void SetName(string newValue) => this._name = newValue;

        public int GetAge() => this._age;
        public void SetAge(int newValue) => this._age = newValue;*/

        // Stage 2 (fields + full properties)
        /*private string _name;
        private int _age;

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public int Age
        {
            get => this._age;
            set => this._age = value;
        }*/

        // Stage 3 (auto properties)
        public string Name { get; set; }
        public int Age { get; set; }

        /*public Person()
        {
            this.BankAccounts = new List<BankAccount>();
        }*/

        public List<BankAccount> BankAccounts { get; } = new List<BankAccount>();

        public string IntroduceYourself()
        {
            return $"I am {this.Name}. I am {this.Age}-years-old.";
        }

        public decimal GetBalance()
        {
            return this.BankAccounts.Sum(ba => ba.Balance);
        }
    }
}
