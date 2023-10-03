namespace Cars
{
    public class Seat : BaseCar
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        protected override string Manufacturer { get; } = "Seat";
    }
}
