using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class ComponentDecorator : IComponent
    {
        // How to implement the "Decorator" design pattern?
        private readonly IComponent _decoratedComponent;

        public ComponentDecorator(IComponent wrappedComponent)
        {
            this._decoratedComponent = wrappedComponent;
        }

        public void DoSomeWork()
        {
            Console.WriteLine("-> The following line will be produced by a decorated component.");
            this._decoratedComponent.DoSomeWork();
        }
    }
}
