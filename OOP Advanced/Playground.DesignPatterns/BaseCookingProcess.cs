using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public abstract class BaseCookingProcess : IActionable
    {
        public void Execute()
        {
            Console.WriteLine("1. First phase - buying products");
            this.BuyProducts();

            Console.WriteLine("2. Second phase - cooking the dish");
            this.CookDish();

            Console.WriteLine("3. Third phase - serving");
            this.ServeDish();
        }

        protected abstract void ServeDish();
        protected abstract void CookDish();
        protected abstract void BuyProducts();
    }
}
