using System;

internal class SubscriptionParkingSpot : ParkingSpot
{
    public string RegistrationPlate { get; }

    public SubscriptionParkingSpot(int id, bool occupied, double price, string registrationPlate)
        : base(id, occupied, "subscription", price)
    {
        if (string.IsNullOrEmpty(registrationPlate))
            throw new ArgumentException("Registration plate can’t be null or empty!", nameof(registrationPlate));

        this.RegistrationPlate = registrationPlate;
    }

    public override bool ParkVehicle(string registrationPlate, int hoursParked, string type)
    {
        if (registrationPlate != this.RegistrationPlate) return false;
        return base.ParkVehicle(registrationPlate, hoursParked, type);
    }

    public override double CalculateTotal()
    {
        return 0;
    }
}

