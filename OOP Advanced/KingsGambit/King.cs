using KingsGambit.Interface;

namespace KingsGambit
{
    public class King : IPerson
    {
        public event EventHandler? Attacked;
        public string Name { get; }

        public King(string name)
        {
            this.Name = name;
        }

        public void HandleAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            if (this.Attacked is null) return;

            this.Attacked.Invoke(this, EventArgs.Empty);
        }
    }
}
