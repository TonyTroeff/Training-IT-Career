namespace Playground.DesignPatterns.Interfaces
{
    public interface IBeverage
    {
        string CustomerName { get; }
        string Name { get; }
        decimal Price { get; }
        string Describe();
    }
}
