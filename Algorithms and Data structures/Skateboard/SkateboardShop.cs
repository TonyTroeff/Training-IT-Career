using System;
using System.Collections.Generic;
using System.Linq;

namespace Skateboard
{
    public class SkateboardShop
    {
        public SkateboardShop(string name)
        {
            this.Name = name;
            this.Skateboards = new List<Skateboard>();
        }

        public string Name { get; }

        public List<Skateboard> Skateboards { get; }

        public void AddSkateboard(string model, double price)
        {
            var skateboard = new Skateboard(model, price);
            this.Skateboards.Add(skateboard);
        }

        public double AveragePriceInRange(double start, double end)
        {
            double sum = 0;
            int count = 0;

            foreach (var skateboard in this.Skateboards)
            {
                if (skateboard.Price >= start && skateboard.Price <= end)
                {
                    sum += skateboard.Price;
                    count++;
                }
            }

            if (count == 0) return 0;
            return sum / count;
        }

        public List<string> FilterSkateboardsByPrice(double price)
            => this.Skateboards.Where(x => x.Price < price).Select(x => x.Model).ToList();

        public List<Skateboard> SortAscendingByModel()
        {
            this.Skateboards.Sort((x, y) => x.Model.CompareTo(y.Model));
            return this.Skateboards;
        }

        public List<Skateboard> SortDescendingByPrice()
        {
            this.Skateboards.Sort((x, y) => y.Price.CompareTo(x.Price));
            return this.Skateboards;
        }

        public bool CheckSkateboardIsInShop(string model)
            => this.Skateboards.Any(x => x.Model == model);

        public string[] ProvideInformationAboutAllSkateboards()
            => this.Skateboards.Select(x => x.ToString()).ToArray();
    }
}
