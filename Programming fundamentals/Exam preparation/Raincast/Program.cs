using System;
using System.Linq;

namespace Raincast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string type = string.Empty, source = string.Empty;

            while (inputLine != "Davai Emo")
            {
                string[] inputData = inputLine.Split(": ");
                string left = inputData[0], right = inputData[1];

                if (type == string.Empty)
                {
                    if (left == "Type" && (right == "Normal" || right == "Warning" || right == "Danger"))
                        type = right;
                }
                else if (source == string.Empty)
                {
                    if (left == "Source" && right.All(char.IsLetterOrDigit))
                        source = right;
                }
                else
                {
                    if (left == "Forecast" && right.All(x => x != '!' && x != '.' && x != ',' && x != '?'))
                    {
                        Console.WriteLine($"({type}) {source} ~ {right}");
                        type = string.Empty;
                        source = string.Empty;
                    }
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}