using Cars.Interfaces;

namespace Cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(List<int>).Name);

            ICar seat = new Seat("Leon", "Grey");
            Tesla tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());

            Console.WriteLine(tesla.ToString());
            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());

            Console.WriteLine(tesla.GetInfo());
        }
    }
}