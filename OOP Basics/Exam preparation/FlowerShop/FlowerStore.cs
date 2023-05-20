using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShop
{
    internal class FlowerStore
    {
        private readonly List<Flower> _flowers = new List<Flower>();
        private string _name;

        public FlowerStore(string name)
        {
            this.Name = name;
        }

        public string Name 
        { 
            get => this._name;
            private set
            {
                if (value is null || value.Length < 6) throw new ArgumentException("Invalid flower store name!");
                this._name = value;
            }
        }

        public void AddFlower(Flower flower)
        {
            if (flower == null) return;
            this._flowers.Add(flower);
        }

        public bool SellFlower(Flower flower)
        {
            if (flower == null) return false;

            int flowerToRemoveIndex = this._flowers.FindIndex(f => f.Type == flower.Type && f.Price == flower.Price && f.Color == flower.Color);
            if (flowerToRemoveIndex == -1) return false;

            this._flowers.RemoveAt(flowerToRemoveIndex);
            return true;
        }

        public double CalculateTotalPrice() => this._flowers.Sum(f => f.Price);

        public Flower GetFlowerWithHighestPrice()
        {
            // In future versions of .NET we can use .MaxBy()
            if (this._flowers.Count == 0) return null;
            
            int maxPriceIndex = 0;
            for (int i = 1; i < this._flowers.Count; i++)
            {
                if (this._flowers[i].Price > this._flowers[maxPriceIndex].Price) maxPriceIndex = i;
            }

            return this._flowers[maxPriceIndex];
        }

        public Flower GetFlowerWithLowestPrice()
        {
            // In future versions of .NET we can use .MinBy()
            if (this._flowers.Count == 0) return null;

            int minPriceIndex = 0;
            for (int i = 1; i < this._flowers.Count; i++)
            {
                if (this._flowers[i].Price < this._flowers[minPriceIndex].Price) minPriceIndex = i;
            }

            return this._flowers[minPriceIndex];
        }

        public void RenameFlowerStore(string newName) => this.Name = newName;

        public void SellAllFlowers() => this._flowers.Clear();

        public override string ToString()
        {
            if (this._flowers.Count == 0) return $"Flower store {this.Name} has no available flowers.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Flower store {this.Name} has {this._flowers.Count} flower/s:");
            foreach (var flower in this._flowers)
                sb.AppendLine(flower.ToString());

            return sb.ToString().Trim();
        }
    }
}
