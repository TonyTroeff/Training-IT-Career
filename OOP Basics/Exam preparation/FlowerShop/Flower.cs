using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    internal class Flower
    {
        public Flower(string type, string color, double price)
        {
            if (price > 100) throw new ArgumentException("Invalid flower price!");

            this.Type = type;
            this.Color = color;
            this.Price = price;
        }

        public string Type { get; }

        public string Color { get; }

        public double Price { get; }

        public override string ToString()
        {
            return $"Flower {this.Type} with color {this.Color} costs {this.Price:f2}";
        }
    }
}
