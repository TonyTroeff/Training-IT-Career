using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class Water : BaseBeverage, IBeverage
    {
        public Water(string customerName) : base(customerName)
        {
        }

        public override string Name => "Mineral water";
        public override decimal Price => 1;

        public override string Describe() => "A bottle of mineral water";
    }
}
