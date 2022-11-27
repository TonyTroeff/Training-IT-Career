using System;

namespace Exam2_PoolPipes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pipe1Debit = int.Parse(Console.ReadLine());
            int pipe2Debit = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double pipe1Fill = pipe1Debit * hours;
            double pipe2Fill = pipe2Debit * hours;
            double totalFill = pipe1Fill + pipe2Fill;

            if (totalFill > volume)
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {totalFill - volume:f1} liters.");
            }
            else
            {
                double fillPercent = totalFill / volume * 100;
                double pipe1FillPercent = pipe1Fill / totalFill * 100;
                double pipe2FillPercent = pipe2Fill / totalFill * 100;
                
                Console.WriteLine($"The pool is {Math.Truncate(fillPercent)}% full. Pipe 1: {Math.Truncate(pipe1FillPercent)}%. Pipe 2: {Math.Truncate(pipe2FillPercent)}%.");
            }
        }
    }
}
