using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodHand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> cardsByPerson = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] inputData = input.Split(": ");
                string personName = inputData[0];
                string[] cards = inputData[1].Split(", ");

                if (!cardsByPerson.ContainsKey(personName))
                    cardsByPerson[personName] = new HashSet<string>();
                for (int i = 0; i < cards.Length; i++)
                    cardsByPerson[personName].Add(cards[i]);

                input = Console.ReadLine();
            }

            foreach (var (person, cards) in cardsByPerson)
                Console.WriteLine($"{person}: {cards.Sum(CalculateNumericValue)}");
        }

        static int CalculateNumericValue(string card)
        {
            char type = card[card.Length - 1];
            
            int typeMultiplier = 0;
            if (type == 'S') typeMultiplier = 4;
            else if (type == 'H') typeMultiplier = 3;
            else if (type == 'D') typeMultiplier = 2;
            else if (type == 'C') typeMultiplier = 1;

            int numericValue = 0;
            if (char.IsDigit(card[0]))
            {
                if (card[0] == '1' && card[1] == '0') numericValue = 10;
                else numericValue = card[0] - '0';
            }
            else if (card[0] == 'J') numericValue = 11;
            else if (card[0] == 'Q') numericValue = 12;
            else if (card[0] == 'K') numericValue = 13;
            else if (card[0] == 'A') numericValue = 14;

            return typeMultiplier * numericValue;
        }
    }
}