namespace Playground.Classes
{
    // Every class has a default parameter-less constructor when none is defined.
    public class Person
    {
        // This is a constructor!
        // Its structure is: <access_modifier> <type_name>(<parameters_list>) { <body> }
        public Person()
        {
        }

        public Person(string name)
            : this()
        {
            this.Name = name;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        // This is a read-only property.
        // It would translate to something like this:
        /* 
        private readonly string name;
        public string GetName() => this.name;
        */
        public string Name { get; }
        
        public int Age { get; private set; }
    }
}
