namespace Supermarket
{
    internal class Product
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; }
        public double Price { get; }

        public override string ToString() => $"Product {this.Name} costs {this.Price:f2} lv.";
    }
}
