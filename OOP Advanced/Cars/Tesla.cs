using Cars.Interfaces;

namespace Cars
{
    public class Tesla : BaseCar, IElectricCar
    {
        public int Battery { get; }

        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        protected override string Manufacturer { get; } = "Tesla";

        public override string ToString() => $"{base.ToString()} with {this.Battery} Batteries";
    }
}
