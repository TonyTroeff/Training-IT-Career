namespace Vehicles
{
    public class Car : BaseVehicle
    {
        public Car(double fuelAmount, double fuelConsumption)
            : base(fuelAmount, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}
