using Machines.Interfaces;

namespace Machines
{
    public abstract class BaseMachine : IMachine
    {
        public abstract string MachineType { get; }

        public bool Start()
        {
            // If we have such code, it disobeys the "Liskov substitution" principle
            // In case we need such functionality, define an additional virtual or abstract method that can be overridden from the inheritors.
            /*if (this.GetType() == typeof(Car))
            {
                Console.WriteLine("This is a car");
            }
            else if (this.GetType() == typeof(Truck))
            {
                Console.WriteLine("This is a heavy truck");
            }*/

            Console.WriteLine($"{this.MachineType} starting...");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine($"{this.MachineType} stopping...");
            return true;
        }
    }
}
