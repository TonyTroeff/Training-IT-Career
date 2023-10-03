using Machines.Interfaces;

namespace Machines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMachine car = new Airplane();

            MachineOperator machineOperator = new MachineOperator(car);
            machineOperator.Start();
            machineOperator.Stop();
        }
    }
}