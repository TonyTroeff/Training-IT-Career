using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class ParkingController
{
    private readonly List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

    public string CreateParkingSpot(List<string> args)
    {
        int id = int.Parse(args[0]);
        ParkingSpot existingParkingSpot = this.GetParkingSpot(id);
        if (existingParkingSpot != null) return $"Parking spot {id} is already registered!";

        bool occupied = bool.Parse(args[1]);
        string type = args[2];
        double price = double.Parse(args[3]);

        ParkingSpot parkingSpot = null;
        if (type == "car") parkingSpot = new CarParkingSpot(id, occupied, price);
        else if (type == "bus") parkingSpot = new BusParkingSpot(id, occupied, price);
        else if (type == "subscription")
        {
            string registrationPlate = args[4];
            parkingSpot = new SubscriptionParkingSpot(id, occupied, price, registrationPlate);
        }

        if (parkingSpot == null) return "Unable to create parking spot!";

        this.parkingSpots.Add(parkingSpot);
        return $"Parking spot {id} was successfully registered in the system!";
    }

    public string ParkVehicle(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        ParkingSpot parkingSpot = this.GetParkingSpot(parkingSpotId);
        if (parkingSpot == null) return $"Parking spot {parkingSpotId} not found!";

        string registrationPlate = args[1];
        int hoursParked = int.Parse(args[2]);
        string type = args[3];

        bool couldPark = parkingSpot.ParkVehicle(registrationPlate, hoursParked, type);
        if (!couldPark) return $"Vehicle {registrationPlate} can't park at {parkingSpotId}.";

        return $"Vehicle {registrationPlate} parked at {parkingSpotId} for {hoursParked} hours.";
    }

    public string FreeParkingSpot(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        ParkingSpot parkingSpot = this.GetParkingSpot(parkingSpotId);
        if (parkingSpot == null) return $"Parking spot {parkingSpotId} not found!";
        if (!parkingSpot.Occupied) return $"Parking spot {parkingSpotId} is not occupied.";

        parkingSpot.Occupied = false;
        return $"Parking spot {parkingSpotId} is now free!";
    }

    public string GetParkingSpotById(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        ParkingSpot parkingSpot = this.GetParkingSpot(parkingSpotId);
        if (parkingSpot == null) return $"Parking spot {parkingSpotId} not found!";

        return parkingSpot.ToString();
    }

    public string GetParkingIntervalsByParkingSpotIdAndRegistrationPlate(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        ParkingSpot parkingSpot = this.GetParkingSpot(parkingSpotId);
        if (parkingSpot == null) return $"Parking spot {parkingSpotId} not found!";

        string registrationPlate = args[1];

        List<ParkingInterval> parkingIntervals = parkingSpot.GetAllParkingIntervalsByRegistrationPlate(registrationPlate);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Parking intervals for parking spot {parkingSpotId}:");
        foreach (ParkingInterval interval in parkingIntervals)
            sb.AppendLine(interval.ToString());

        return sb.ToString().TrimEnd();
    }

    public string CalculateTotal(List<string> args)
    {
        double totalRevenue = this.parkingSpots.Sum(x => x.CalculateTotal());
        return $"Total revenue from the parking: {totalRevenue:F2} BGN";
    }

    private ParkingSpot GetParkingSpot(int parkingSpotId) => this.parkingSpots.FirstOrDefault(x => x.Id == parkingSpotId);
}
