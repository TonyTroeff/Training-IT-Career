namespace Machines.Interfaces
{
    public interface IMachine
    {
        string MachineType { get; }

        bool Start();
        bool Stop();
    }
}
