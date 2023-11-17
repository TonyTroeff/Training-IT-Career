namespace Playground.DesignPatterns
{
    public class SaladCookingProcess : BaseCookingProcess
    {
        protected override void BuyProducts()
        {
            Console.WriteLine("We need to buy one cucumber and four tomatoes.");
        }

        protected override void CookDish()
        {
            Console.WriteLine("Cut the cucumber and tomatoes");
        }

        protected override void ServeDish()
        {
            Console.WriteLine("Put everything in a bowl");
        }
    }
}
