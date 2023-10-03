namespace Playground.Inheritance
{
    public class Employee : Person
    {
        public Employee(string name, int age, string address, string company)
            : base(name, age, address)
        {
            this.Company = company;
        }

        public string Company { get; }

        public override string Greet(string name)
        {
            return $"Hello, Mr./Mrs. {name}!";
        }

        public override string Introduce()
        {
            string baseIntroduction = base.Introduce();
            return $"{baseIntroduction}; Company: {this.Company}";
        }
    }
}
