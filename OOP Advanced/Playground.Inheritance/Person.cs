using System.Runtime.InteropServices;

namespace Playground.Inheritance
{
    // If a class is abstract, it means:
    // - It cannot be instantiated directly. As a consequence, its constructor does not need to be public.
    // - It can define abstract members.
    public abstract class Person
    {
        public string Name { get; }
        public int Age { get; }
        public string Address { get; }

        protected Person(string name, int age, string address)
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }

        // Virtual methods offer an implementation
        // If this method is not overridden by the inheriting class, this default implementation will be used.
        public virtual string Introduce()
        {
            return $"Name: {this.Name}; Age: {this.Age}; Address: {this.Address}";
        }

        public abstract string Greet(string name);
    }
}
