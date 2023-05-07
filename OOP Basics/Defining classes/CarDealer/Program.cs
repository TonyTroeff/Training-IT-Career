using System;
using System.Collections.Generic;

namespace CarDealer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> enginesByModel = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                Engine engine = ReadEngine();
                enginesByModel[engine.Model] = engine;
            }

            int m = int.Parse(Console.ReadLine());
            Car[] cars = new Car[m];

            for (int i = 0; i < m; i++)
                cars[i] = ReadCar(enginesByModel);

            for (int i = 0; i < m; i++)
                Console.WriteLine(cars[i]);
        }

        private static Engine ReadEngine()
        {
            string[] engineInput = Console.ReadLine().Split();
            Engine engine = new Engine
            {
                Model = engineInput[0],
                Power = int.Parse(engineInput[1])
            };

            if (engineInput.Length == 4)
            {
                engine.Displacement = int.Parse(engineInput[2]);
                engine.Efficiency = engineInput[3];
            }
            else if (engineInput.Length == 3)
            {
                if (int.TryParse(engineInput[2], out int displacement))
                    engine.Displacement = displacement;
                else engine.Efficiency = engineInput[2];
            }

            return engine;
        }

        private static Car ReadCar(Dictionary<string, Engine> enginesByModel)
        {
            string[] carInput = Console.ReadLine().Split();

            Car car = new Car
            {
                Model = carInput[0],
                Engine = enginesByModel[carInput[1]]
            };

            if (carInput.Length == 4)
            {
                car.Weight = int.Parse(carInput[2]);
                car.Color = carInput[3];
            }
            else if (carInput.Length == 3)
            {
                if (int.TryParse(carInput[2], out int weight))
                    car.Weight = weight;
                else car.Color = carInput[2];
            }

            return car;
        }
    }
}