using System;
using System.Text;

public class ParkingInterval
{
    public ParkingSpot ParkingSpot { get; }
    public string RegistrationPlate { get; }
    public int HoursParked { get; }
    public double Revenue
    {
        get
        {
            // This should be avoided at all costs!
            // if (this.ParkingSpot is SubscriptionParkingSpot) return 0;
            return this.HoursParked * this.ParkingSpot.Price;
        }
    }

    public ParkingInterval(ParkingSpot parkingSpot, string registrationPlate, int hoursParked)
    {
        if (string.IsNullOrEmpty(registrationPlate))
            throw new ArgumentException("Registration plate can’t be null or empty!", nameof(registrationPlate));

        if (hoursParked <= 0)
            throw new ArgumentException("Hours parked can’t be zero or negative!", nameof(hoursParked));

        this.ParkingSpot = parkingSpot;
        this.RegistrationPlate = registrationPlate;
        this.HoursParked = hoursParked;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"> Parking Spot #{this.ParkingSpot.Id}");
        sb.AppendLine($"> RegistrationPlate: {this.RegistrationPlate}");
        sb.AppendLine($"> HoursParked: {this.HoursParked}");
        sb.Append($"> Revenue: {this.Revenue:f2} BGN");

        return sb.ToString();
    }
}