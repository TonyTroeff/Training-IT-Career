﻿using System;

namespace TriangleOfDollar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++) Console.Write('$');
                Console.WriteLine();
            }
        }
    }
}
