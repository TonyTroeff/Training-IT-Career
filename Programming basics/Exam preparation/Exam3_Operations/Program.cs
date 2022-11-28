using System;

namespace Exam3_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            char mathOperator = char.Parse(Console.ReadLine());

            if ((mathOperator == '/' || mathOperator == '%') && b == 0)
            {
                Console.WriteLine($"Cannot divide {a} by zero.");
            }
            else
            {
                Console.Write($"{a} {mathOperator} {b} = ");
                if (mathOperator == '/') Console.WriteLine((double)a / b);
                else if (mathOperator == '%') Console.WriteLine(a % b);
                else
                {
                    int result = 0;
                    if (mathOperator == '+') result = a + b;
                    else if (mathOperator == '-') result = a - b;
                    else if (mathOperator == '*') result = a * b;

                    Console.Write(result);
                    if (result % 2 == 0) Console.Write(" - even");
                    else Console.Write(" - odd");

                    Console.WriteLine();
                }
            }
        }
    }
}
