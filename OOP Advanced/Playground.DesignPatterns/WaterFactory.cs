using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class WaterFactory : IBeverageFactory
    {
        public IBeverage CreateBeverage(string customerName)
            => new Water(customerName);
    }
}
