using Machines.Interfaces;

namespace Machines
{
    public class MachineOperator
    {
        private readonly IMachine _machine;

        public MachineOperator(IMachine machine)
        {
            this._machine = machine;
        }

        public bool Start() => this._machine.Start();

        public bool Stop() => this._machine.Stop();
    }
}
