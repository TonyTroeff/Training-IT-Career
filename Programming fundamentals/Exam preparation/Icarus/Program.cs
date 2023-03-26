namespace Icarus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] plane = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int position = int.Parse(Console.ReadLine());
            int damage = 1;

            string command = Console.ReadLine();
            while (command != "Supernova")
            {
                string[] commandData = command.Split();
                string direction = commandData[0];
                int steps = int.Parse(commandData[1]);

                if (direction == "left")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (position == 0)
                        {
                            position = plane.Length;
                            damage++;
                        }

                        position--;
                        plane[position] -= damage;
                    }
                }
                else if (direction == "right")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (position == plane.Length - 1)
                        {
                            position = -1;
                            damage++;
                        }

                        position++;
                        plane[position] -= damage;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', plane));
        }
    }
}