namespace Playground.DesignPatterns.Interfaces
{
    public interface IBeverageFactory
    {
        IBeverage CreateBeverage(string customerName);
    }
}
