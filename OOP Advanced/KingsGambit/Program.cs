using KingsGambit.Interface;

namespace KingsGambit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            King king = InstantiateKing();
            var (guards, footmen, defenderByName) = InstantiateDefenders();

            foreach (var defenderName in guards.Concat(footmen))
                king.Attacked += defenderByName[defenderName].Defend;

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Attack" && commandArgs[1] == "King") king.HandleAttack();
                else if (commandArgs[0] == "Kill") KillDefender(king, defenderByName, commandArgs[1]);

                command = Console.ReadLine();
            }
        }

        private static void KillDefender(King king, IDictionary<string, IDefender> defenderByName, string defenderName)
        {
            if (!defenderByName.ContainsKey(defenderName)) Console.WriteLine("Such defender cannot be found.");
            else
            {
                var defender = defenderByName[defenderName];
                king.Attacked -= defender.Defend;

                defenderByName.Remove(defenderName);
            }
        }

        static King InstantiateKing()
        {
            string kingName = Console.ReadLine();
            return new King(kingName);
        }

        static (string[] Guards, string[] Footmen, IDictionary<string, IDefender> Defenders) InstantiateDefenders()
        {
            string[] guardsNames = Console.ReadLine().Split();
            string[] footmenNames = Console.ReadLine().Split();

            Dictionary<string, IDefender> result = new Dictionary<string, IDefender>();
            for (int i = 0; i < guardsNames.Length; i++)
                result[guardsNames[i]] = new RoyalGuard(guardsNames[i]);
            for (int i = 0; i < footmenNames.Length; i++)
                result[footmenNames[i]] = new Footman(footmenNames[i]);

            return (guardsNames, footmenNames, result);
        }
    }
}