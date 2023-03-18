using System;

namespace RobotMovement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] xMovement = { 1, 0, -1, 0 };
            int[] yMovement = { 0, -1, 0, 1 };

            string commands = Console.ReadLine();

            int xPosition = 0, yPosition = 0;
            int movementIndex = 0;

            int index = 0;
            while (index < commands.Length)
            {
                bool increase = true;
                if (commands[index] == 'L')
                {
                    if (movementIndex == 0) movementIndex = 4;
                    movementIndex--;
                }
                else if (commands[index] == 'R')
                {
                    movementIndex = (movementIndex + 1) % 4;
                }
                else
                {
                    increase = false;
                    int num = 0;
                    while (index < commands.Length && char.IsDigit(commands[index]))
                    {
                        num = num * 10 + commands[index] - '0';
                        index++;
                    }

                    xPosition += xMovement[movementIndex] * num;
                    yPosition += yMovement[movementIndex] * num;
                }

                if (increase) index++;
            }

            double distance = Math.Sqrt(xPosition * xPosition + yPosition * yPosition);
            Console.WriteLine($"Position: (x: {xPosition}, y: {yPosition}), Distance = {distance:f2} m");
        }
    }
}