using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class ParkingSpot
{
    private readonly List<ParkingInterval> parkingIntervals = new List<ParkingInterval>();

    public int Id { get; }
    public bool Occupied { get; set; }
    public string Type { get; }
    public double Price { get; }

    public ParkingSpot(int id, bool occupied, string type, double price)
    {
        if (price <= 0)
            throw new ArgumentException("Parking price cannot be less or equal to 0!", nameof(price));

        this.Id = id;
        this.Occupied = occupied;
        this.Type = type;
        this.Price = price;
    }

    public virtual bool ParkVehicle(string registrationPlate, int hoursParked, string type)
    {
        if (this.Occupied || this.Type != type) return false;

        ParkingInterval parkingInterval = new ParkingInterval(this, registrationPlate, hoursParked);
        this.parkingIntervals.Add(parkingInterval);

        this.Occupied = true;

        return true;
    }

    public List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate)
        => this.parkingIntervals.Where(x => x.RegistrationPlate == registrationPlate).ToList();

    public virtual double CalculateTotal() => this.parkingIntervals.Sum(x => x.Revenue);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"> Parking Spot #{this.Id}");
        sb.AppendLine($"> Occupied: {this.Occupied}");
        sb.AppendLine($"> Type: {this.Type}");
        sb.Append($"> Price per hour: {this.Price:f2} BGN");

        return sb.ToString();
    }

}
