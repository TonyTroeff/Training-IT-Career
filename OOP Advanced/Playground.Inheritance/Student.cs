namespace Playground.Inheritance
{
    public class Student : Person
    {
        public Student(string name, int age, string address, string school)
            : base(name, age, address)
        {
            this.School = school;
        }

        public string School { get; }

        public sealed override string Greet(string name)
        {
            return $"Hi, {name}";
        }

        public override string Introduce()
        {
            string baseIntroduction = base.Introduce();
            return $"{baseIntroduction}; School: {this.School}";
        }
    }
}
