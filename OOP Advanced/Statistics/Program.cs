namespace Statistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                people[i] = new Person(input[0], int.Parse(input[1]));
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
                Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}