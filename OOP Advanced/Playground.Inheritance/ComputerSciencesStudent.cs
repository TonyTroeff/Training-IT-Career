namespace Playground.Inheritance
{
    public class ComputerSciencesStudent : Student
    {
        public ComputerSciencesStudent(string name, int age, string address, string school)
            : base(name, age, address, school)
        {
        }

        // We cannot override sealed methods.
        // public override string Greet(string name)
        //     => $"{base.Greet(name)} (I am a student in CS)";
    }
}
