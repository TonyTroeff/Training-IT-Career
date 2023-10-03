using Cars.Interfaces;

namespace Cars
{
    public abstract class BaseCar : ICar
    {
        public string Model { get; }
        public string Color { get; }

        protected BaseCar(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        protected abstract string Manufacturer { get; }

        public virtual string Start() => "Engine start";

        public virtual string Stop() => "Breaaak!";

        public override string ToString()
        {
            // In order to access the "Manufacturer" we have two options:
            // 1. Define an abstract method/property
            return $"{this.Color} {this.Manufacturer} {this.Model}";

            // 2. Use the type name. This solution required equivalence between the type name and the manufacturer. Moreover, it will not work for generic types.
            // return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
