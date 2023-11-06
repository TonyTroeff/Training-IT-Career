
using Playground.DesignPatterns.Interfaces;

namespace Playground.DesignPatterns
{
    public class ComponentComposite : IComponent
    {
        private readonly List<IComponent> _children = new List<IComponent>();

        public string Name { get; }
        public IReadOnlyCollection<IComponent> Children => this._children.AsReadOnly();

        public ComponentComposite(string name)
        {
            this.Name = name;
        }

        public void AddChild(IComponent component)
        {
            if (component is null) return;

            this._children.Add(component);
        }

        public void DoSomeWork()
        {
            Console.WriteLine($"Executing DoSomeWork from composite {this.Name}");
            foreach (var child in this.Children)
                child.DoSomeWork();
        }
    }
}
