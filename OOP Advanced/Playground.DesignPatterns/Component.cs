using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class Component : IComponent
    {
        public string Name { get; }

        public Component(string name)
        {
            this.Name = name;
        }

        public void DoSomeWork()
        {
            // This is just for demonstrational purposes
            Console.WriteLine($"Executing DoSomeWork from component {this.Name}");
        }
    }
}
