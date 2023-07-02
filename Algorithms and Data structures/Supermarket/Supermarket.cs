using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket
{
    internal class Supermarket
    {
        public Supermarket(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public List<Product> Products { get; } = new List<Product>();

        public void AddProduct(string name, double price)
        {
            Product product = new Product(name, price);
            this.Products.Add(product);
        }

        public double AveragePriceInRange(double start, double end)
        {
            double sum = 0;
            int count = 0;

            for (int i = 0; i < this.Products.Count; i++)
            {
                if (this.Products[i].Price >= start && this.Products[i].Price <= end)
                {
                    sum += this.Products[i].Price;
                    count++;
                }
            }

            if (count == 0) return 0;
            return sum / count;
        }

        public List<string> FilterProductsByPrice(double price)
            => this.Products.Where(x => x.Price < price).Select(x => x.Name).ToList();
        /*{
            List<string> result = new List<string>(capacity: this.Products.Count);
            for (int i = 0; i < this.Products.Count; i++)
            {
                if (this.Products[i].Price < price) result.Add(this.Products[i].Name);
            }

            return result;
        }*/

        public List<Product> SortAscendingByName()
        {
            // this.Products = this.Products.OrderBy(x => x.Name).ToList();
            this.Products.Sort((x, y) => string.Compare(x.Name, y.Name));
            return this.Products;
        }

        public List<Product> SortDescendingByPrice()
        {
            // this.Products = this.Products.OrderByDescending(x => x.Price).ToList();
            this.Products.Sort((x, y) => -1 * x.Price.CompareTo(y.Price));
            return this.Products;
        }

        public bool CheckProductIsInSupermarket(string name)
            => this.Products.Any(x => x.Name == name);
        /*{
            for (int i = 0; i < this.Products.Count; i++)
            {
                if (this.Products[i].Name == name) return true;
            }

            return false;
        }*/

        public string[] ProvideInformationAboutAllProducts()
            => this.Products.Select(x => x.ToString()).ToArray();
        /*{
            string[] result = new string[this.Products.Count];
            for (int i = 0; i < this.Products.Count; i++)
                result[i] = this.Products[i].ToString();

            return result;
        }*/
    }
}
