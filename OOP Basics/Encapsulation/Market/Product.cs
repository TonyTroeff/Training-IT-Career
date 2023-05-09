using System;

namespace Market
{
    internal class Product
    {
        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
            if (price < 0) throw new ArgumentException("Money cannot be negative");

            this.Name = name;
            this.Price = price;
        }

        public string Name { get; }
        public decimal Price { get; }
    }
}
