using System;
using System.Collections.Generic;

namespace Market
{
    internal class Person
    {
        private List<Product> bag = new List<Product>();

        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
            if (money < 0) throw new ArgumentException("Money cannot be negative");

            this.Name = name;
            this.Money = money;
        }

        public string Name { get; }
        public decimal Money { get; private set; }
        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();
    
        public bool Buy(Product product)
        {
            if (product.Price > this.Money) return false;

            this.Money -= product.Price;
            this.bag.Add(product);
            return true;
        }
    }
}
