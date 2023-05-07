namespace RawDeliveryData
{
    public class Tyre
    {
        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; }
        public int Age { get; }
    }
}
