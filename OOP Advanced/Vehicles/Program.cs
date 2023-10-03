using Vehicles.Interfaces;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));

            string[] truckData = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandData = Console.ReadLine().Split();

                string command = commandData[0];
                IVehicle operativeVehicle = SelectVehicle(commandData[1], car, truck);
                ExecuteCommand(command, operativeVehicle, commandData);
            }

            Console.WriteLine($"Car: {car.FuelAmount:f2}");
            Console.WriteLine($"Truck: {truck.FuelAmount:f2}");
        }

        static IVehicle SelectVehicle(string vehicleType, Car car, Truck truck)
        {
            if (vehicleType == "Car") return car;
            if (vehicleType == "Truck") return truck;

            return null;
        }

        static void ExecuteCommand(string command, IVehicle vehicle, string[] args)
        {
            if (command == "Drive")
            {
                double distance = double.Parse(args[2]);
                bool canTravel = vehicle.Drive(distance);

                if (canTravel) Console.WriteLine($"{args[1]} travelled {distance} km");
                else Console.WriteLine($"{args[1]} needs refueling");
            }
            else if (command == "Refuel")
            {
                double fuelInLiters = double.Parse(args[2]);
                vehicle.Refuel(fuelInLiters);
            }
        }
    }
}