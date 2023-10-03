using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interfaces;

namespace Vehicles
{
    public abstract class BaseVehicle : IVehicle
    {
        public double FuelAmount { get; private set; }
        public virtual double FuelConsumption { get; }

        protected BaseVehicle(double fuelAmount, double fuelConsumption)
        {
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public bool Drive(double distance)
        {
            double requiredFuel = distance * this.FuelConsumption;
            if (requiredFuel > this.FuelAmount) return false;

            this.FuelAmount -= requiredFuel;
            return true;
        }

        public virtual void Refuel(double amount)
        {
            this.FuelAmount += amount;
        }
    }
}
