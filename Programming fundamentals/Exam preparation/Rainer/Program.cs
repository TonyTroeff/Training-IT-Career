namespace Rainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] playground = new int[inputSequence.Length - 1];
            for (int i = 0; i < playground.Length; i++) playground[i] = inputSequence[i];

            int donaldIndex = inputSequence[inputSequence.Length - 1];

            bool play = true;
            int steps = 0;
            while (play)
            {
                for (int i = 0; i < playground.Length; i++)
                    playground[i]--;

                play = playground[donaldIndex] != 0;
                if (play)
                {
                    for (int i = 0; i < playground.Length; i++)
                    {
                        if (playground[i] == 0) playground[i] = inputSequence[i];
                    }

                    donaldIndex = int.Parse(Console.ReadLine());
                    steps++;
                }
            }

            Console.WriteLine(string.Join(' ', playground));
            Console.WriteLine(steps);
        }
    }
}