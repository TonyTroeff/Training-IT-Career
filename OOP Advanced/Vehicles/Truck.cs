namespace Vehicles
{
    public class Truck : BaseVehicle
    {
        public Truck(double fuelAmount, double fuelConsumption)
            : base(fuelAmount, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double amount)
            => base.Refuel(amount * 0.95);
    }
}
