using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsSkeleton
{
    class Program
    {
        private static Deque<Train> trains = new Deque<Train>();
        private static Stack<Train> history = new Stack<Train>();

        private static void Add(int number, string name, string type, int cars)
        {
            if (type == "F")
            {
                //Add freight trains to back
                trains.AddBack(new Train(number, name, type, cars));
            }
            else
            {
                trains.AddFront(new Train(number, name, type, cars));
            }
        }
        private static void Travel()
        {
            Train nextTrain = GetNextTrain(remove: true);

            if (nextTrain != null)
            {
                Console.WriteLine(nextTrain);
                history.Push(nextTrain);
            }
        }

        private static void Next()
        {
            Train nextTrain = GetNextTrain(remove: false);
            if (nextTrain != null) Console.WriteLine(nextTrain);
        }

        private static Train GetNextTrain(bool remove)
        {
            if (trains.Count == 0) return null;

            Train frontTrain = trains.GetFront();
            Train backTrain = trains.GetBack();

            if (backTrain != null && backTrain.Type == "F" && backTrain.Cars > 15)
            {
                if (remove) trains.RemoveBack();
                return backTrain;
            }
            else if (frontTrain != null && frontTrain.Type == "P")
            {
                if (remove) trains.RemoveFront();
                return frontTrain;
            }
            else if (backTrain != null && backTrain.Type == "F")
            {
                if (remove) trains.RemoveBack();
                return backTrain;
            }
            return null;
        }

        private static void History()
        {
            foreach (Train entry in history)
                Console.WriteLine(entry);
        }

        static void Main(string[] args)
        {

            string[] command;
            do
            {
                command = Console.ReadLine().Split(' ').ToArray();
                switch (command[0])
                {
                    case "Add":
                        Add(int.Parse(command[1]), command[2], command[3], int.Parse(command[4]));
                        break;
                    case "Travel":
                        Travel();
                        break;
                    case "Next":
                        Next();
                        break;
                    case "History":
                        History();
                        break;
                }
            } while (command[0] != "End");

        }


    }
}
