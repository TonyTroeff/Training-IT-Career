using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

namespace RawDeliveryData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToArray();
                var model = new Model(line[0], int.Parse(line[1]), int.Parse(line[2]));
                var payload = new Payload(int.Parse(line[3]), line[4]);
                Tyre[] tyres = new Tyre[4];
                tyres[0] = new Tyre(double.Parse(line[5]), int.Parse(line[6]));
                tyres[1] = new Tyre(double.Parse(line[7]), int.Parse(line[8]));
                tyres[2] = new Tyre(double.Parse(line[9]), int.Parse(line[10]));
                tyres[3] = new Tyre(double.Parse(line[11]), int.Parse(line[12]));
                cars.Add(new Car(model, payload, tyres));
            }

            var type = Console.ReadLine();
            switch (type)
            {
                case "fragile":
                    var fragile = cars.Where(x => x.CarTyres.Any(t => t.Pressure < 1))
                                       .Select(y => y.Model.Name).ToList();
                    Console.WriteLine(string.Join("\n", fragile));
                    break;

                case "flamable":
                    var flamable = cars.Where(x => x.Model.Power > 250)
                                       .Select(y => y.Model.Name).ToList();
                    Console.WriteLine(string.Join("\n", flamable));
                    break;
            }
        }
    }
}