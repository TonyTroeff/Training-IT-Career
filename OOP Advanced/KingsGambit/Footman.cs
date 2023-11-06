using KingsGambit.Interface;

namespace KingsGambit
{
    public class Footman : IPerson, IDefender
    {
        public string Name { get; }

        public Footman(string name)
        {
            this.Name = name;
        }

        public void Defend(object? sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
