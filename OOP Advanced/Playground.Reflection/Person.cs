namespace Playground.Reflection
{
    public class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            this.Name = name;
        }

        public override string ToString() => $"This is a person, called {this.Name}.";
    }
}
