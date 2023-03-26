namespace PhoenixOscarRomeo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, HashSet<string>> squadMatesByCreature = new Dictionary<string, HashSet<string>>();

            while (command != "Blaze it!")
            {
                string[] commandData = command.Split(" -> ");
                string creatureName = commandData[0];
                string squadMateName = commandData[1];

                if (creatureName != squadMateName)
                {
                    if (!squadMatesByCreature.ContainsKey(creatureName))
                        squadMatesByCreature[creatureName] = new HashSet<string>();
                    squadMatesByCreature[creatureName].Add(squadMateName);
                }

                command = Console.ReadLine();
            }

            foreach (var (creatureName, currentCreatureSquadMates) in squadMatesByCreature)
            {
                foreach (var squadMate in currentCreatureSquadMates)
                {
                    if (squadMatesByCreature.ContainsKey(squadMate)
                        && squadMatesByCreature[squadMate].Contains(creatureName))
                    {
                        currentCreatureSquadMates.Remove(squadMate);
                        squadMatesByCreature[squadMate].Remove(creatureName);
                    }
                }
            }

            foreach (var (creatureName, squadMates) in squadMatesByCreature.OrderByDescending(x => x.Value.Count))
                Console.WriteLine($"{creatureName} : {squadMates.Count}");
        }
    }
}