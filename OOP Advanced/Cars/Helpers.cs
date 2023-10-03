using Cars.Interfaces;

namespace Cars
{
    public static class Helpers
    {
        // This is an extension method.
        public static string GetInfo<T>(this T car)
            where T : IElectricCar, ICar
        {
            return $"This car has {car.Battery} batteries. {car.Model}, {car.Color}";
        }
    }
}
