namespace Playground.Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlledList1 controlledList1 = new ControlledList1();

            ControlledList2 controlledList2 = new ControlledList2(new List<int>());

            Employee employee = new Employee("John", 35, "New York", "Apple");
            Helpers.IntroduceOnConsole(employee);
            Helpers.GreetOnConsole(employee, "John Smith");

            Student student = new Student("Petyo", 12, "Gorna Oryahovica", "Purvo");
            Helpers.IntroduceOnConsole(student);
            Helpers.GreetOnConsole(student, "John Smith");

            Student computerSciencesStudent = new ComputerSciencesStudent("Marc", 15, "Sofia", "TUES");
            Helpers.IntroduceOnConsole(computerSciencesStudent);
            Helpers.GreetOnConsole(computerSciencesStudent, "John Smith");
        }
    }
}