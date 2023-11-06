using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class Coffee : BaseBeverage, IBeverage
    {
        public Coffee(string customerName) : base(customerName)
        {
        }

        public override string Name => "Black Coffee";
        public override decimal Price => 3.5m;

        public override string Describe() => "A cup of black coffee";
    }
}
