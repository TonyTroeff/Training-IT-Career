namespace SortPeopleByNameAndAge
{
    internal class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public override string ToString()
            => $"{this.FirstName} {this.LastName} is a {this.Age} years old";
    }
}
