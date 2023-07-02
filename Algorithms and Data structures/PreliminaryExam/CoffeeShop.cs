using System.Collections.Generic;
using System.Linq;

namespace PreliminaryExam
{
    public class CoffeeShop
    {
        public CoffeeShop(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public List<Coffee> Coffees { get; private set; } = new List<Coffee>();

        public void AddCoffee(string type, double price)
        {
            this.Coffees.Add(new Coffee(type, price));
        }

        public double AveragePriceInRange(double start, double end) => this.Coffees.Where(x => x.Price >= start && x.Price <= end).Average(x => x.Price);

        public List<string> FilterCoffeesByPrice(double price) => this.Coffees.Where(x => x.Price < price).Select(x => x.Type).ToList();

        public List<Coffee> SortAscendingByType()
        {
            this.Coffees = this.Coffees.OrderBy(x => x.Type).ToList();
            return this.Coffees;
        }

        public List<Coffee> SortDescendingByPrice()
        {
            this.Coffees = this.Coffees.OrderByDescending(x => x.Price).ToList();
            return this.Coffees;
        }

        public bool CheckCoffeeIsInCoffeeShop(string type) => this.Coffees.Any(x => x.Type == type);

        public string[] ProvideInformationAboutAllCoffees() => this.Coffees.Select(x => x.ToString()).ToArray();
    }
}
