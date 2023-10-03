namespace Playground.Inheritance
{
    public static class Helpers
    {
        public static void IntroduceOnConsole<T>(T person)
            where T : Person
        {
            Console.WriteLine(person.Introduce());
        }

        public static void GreetOnConsole<T>(T person, string name)
            where T : Person
        {
            Console.WriteLine(person.Greet(name));
        }
    }
}
