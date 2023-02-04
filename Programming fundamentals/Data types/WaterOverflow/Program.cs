using System;

namespace WaterOverflow
{
    public class Program
    {
        public static void Main()
        {
            byte capacity = 0; // We use byte because we know that the maximum capacity is 255.
            
            byte n = byte.Parse(Console.ReadLine());
            for (byte i = 0; i < n; i++)
            {
                short litters = short.Parse(Console.ReadLine());

                byte remainingCapacity = (byte) (byte.MaxValue - capacity);
                if (litters <= remainingCapacity) capacity += (byte)litters;
                else Console.WriteLine("Insufficient capacity!");
            }

            Console.WriteLine(capacity);
        }
    }
}