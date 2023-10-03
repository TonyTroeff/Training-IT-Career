namespace Vehicles.Interfaces
{
    public interface IVehicle
    {
        double FuelAmount { get; }
        double FuelConsumption { get; }

        bool Drive(double distance);
        void Refuel(double amount);
    }
}
