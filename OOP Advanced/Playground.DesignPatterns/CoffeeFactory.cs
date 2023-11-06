using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class CoffeeFactory : IBeverageFactory
    {
        public IBeverage CreateBeverage(string customerName)
            => new Coffee(customerName);
    }
}
