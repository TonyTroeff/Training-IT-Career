namespace Family
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] family = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                family[i] = new Person { Name = input[0], Age = int.Parse(input[1]) };
            }

            foreach (Person familyMember in family.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{familyMember.Name} {familyMember.Age}");
            }
        }
    }
}