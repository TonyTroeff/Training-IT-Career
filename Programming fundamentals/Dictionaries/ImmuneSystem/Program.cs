using System;
using System.Collections.Generic;

namespace ImmuneSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialImmuneSystemPower = int.Parse(Console.ReadLine());
            int immuneSystemPower = initialImmuneSystemPower;

            HashSet<string> beatenViruses = new HashSet<string>();
            bool immuneSystemDefeated = false;

            string input = Console.ReadLine();
            while (input != "end")
            {
                int virusPower = CalculateVirusPower(input);
                int timeToBeatVirus = CalculateTimeToBeatVirus(input, virusPower);
                if (beatenViruses.Contains(input)) timeToBeatVirus /= 3;

                Console.WriteLine($"Virus {input}: {virusPower} => {timeToBeatVirus} seconds");
                if (timeToBeatVirus <= immuneSystemPower)
                {
                    int minutes = timeToBeatVirus / 60, seconds = timeToBeatVirus % 60;
                    Console.WriteLine($"{input} defeated in {minutes}m {seconds}s.");

                    immuneSystemPower -= timeToBeatVirus;
                    Console.WriteLine($"Remaining health: {immuneSystemPower}");

                    //immuneSystemPower = Math.Min(initialImmuneSystemPower, (int)(1.2 * immuneSystemPower));
                    immuneSystemPower = (int)(1.2 * immuneSystemPower);
                    if (immuneSystemPower > initialImmuneSystemPower)
                        immuneSystemPower = initialImmuneSystemPower;

                    beatenViruses.Add(input);
                }
                else
                {
                    immuneSystemDefeated = true;
                    break;
                }

                input = Console.ReadLine();
            }

            if (immuneSystemDefeated) Console.WriteLine("Immune System Defeated.");
            else Console.WriteLine($"Final health: {immuneSystemPower}");
        }

        static int CalculateTimeToBeatVirus(string virusName, int virusPower)
        {
            return virusPower * virusName.Length;
        }

        static int CalculateVirusPower(string virusName)
        {
            int sum = 0;
            for (int i = 0; i < virusName.Length; i++) sum += virusName[i];

            return sum / 3;
        }
    }
}