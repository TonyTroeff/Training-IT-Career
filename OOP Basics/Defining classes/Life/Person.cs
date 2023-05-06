using System.Collections.Generic;
using System.Linq;

namespace Life
{
    public class Person
    {
        // prop; Tab; Tab
        // propfull; Tab; Tab;

        private string name;
        private int age;
        private List<BankAccount> accounts = new List<BankAccount>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public List<BankAccount> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }

        public double GetBalance()
        {
            return this.Accounts.Sum(x => x.Balance);
        }
    }
}
