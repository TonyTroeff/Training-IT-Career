using System;

namespace Skateboard
{
    public class Skateboard
    {
        public Skateboard(string model, double price)
        {
            this.Model = model;
            this.Price = price;
        }

        public string Model { get; }
        public double Price { get; }

        public override string ToString() => $"Skateboard {this.Model} costs {this.Price:f2} lv.";
    }
}
