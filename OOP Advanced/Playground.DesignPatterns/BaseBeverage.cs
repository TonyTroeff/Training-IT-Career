using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public abstract class BaseBeverage : IBeverage
    {
        protected BaseBeverage(string customerName)
        {
            this.CustomerName = customerName;
        }

        public string CustomerName { get; }
        public abstract string Name { get; }
        public abstract decimal Price { get; }

        public abstract string Describe();
    }
}
