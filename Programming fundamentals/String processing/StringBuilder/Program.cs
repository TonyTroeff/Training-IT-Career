using System;
using System.Text;

namespace StringBuilderProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialText = Console.ReadLine();
            string[] commandData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandData[0];

            StringBuilder sb = new StringBuilder(initialText);
            if (commandName == "Append") sb.Append(commandData[1]);
            else if (commandName == "Remove")
            {
                int startIndex = int.Parse(commandData[1]);
                int count = int.Parse(commandData[2]);
                sb.Remove(startIndex, count);
            }
            else if (commandName == "Insert")
            {
                int insertIndex = int.Parse(commandData[1]);
                string textToInsert = commandData[2];
                sb.Insert(insertIndex, textToInsert);
            }
            else if (commandName == "Replace")
            {
                string textToReplace = commandData[1];
                string replacement = commandData[2];
                sb.Replace(textToReplace, replacement);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}