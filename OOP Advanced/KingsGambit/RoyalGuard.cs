using KingsGambit.Interface;

namespace KingsGambit
{
    public class RoyalGuard : IPerson, IDefender
    {
        public string Name { get; }

        public RoyalGuard(string name)
        {
            this.Name = name;
        }

        public void Defend(object? sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
