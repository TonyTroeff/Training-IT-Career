using System;
using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int n = int.Parse(Console.ReadLine());

            List<int[]> results = new List<int[]>();
            SolveNQueens(n, row: 0, new int[n], new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), results);

            Console.WriteLine($"There are {results.Count} solutions.");
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"Solution #{i + 1}");
                for (int j = 0; j < results[i].Length; j++)
                {
                    Console.WriteLine($"{new string('.', results[i][j])}@{new string('.', n - (results[i][j] + 1))}");
                }

                Console.WriteLine();
            }*/

            int n = int.Parse(Console.ReadLine());
            string[] labyrinth = new string[n];
            for (int i = 0; i < n; i++) labyrinth[i] = Console.ReadLine();

            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++) visited[i] = new bool[labyrinth[i].Length];

            List<string> results = new List<string>();
            FindAllPaths(labyrinth, 0, 0, new StringBuilder(), visited, results);

            for (int i = 0; i < results.Count; i++)
                Console.WriteLine($"Solution #{i + 1}: {results[i]}");
        }

        private static void SolveNQueens(int n, int row, int[] slots, HashSet<int> usedColumns, HashSet<int> usedPositiveDiagonals, HashSet<int> usedNegativeDiagonals, List<int[]> result)
        {
            if (row == n)
            {
                int[] slotsCopy = new int[slots.Length];
                Array.Copy(slots, slotsCopy, slots.Length);
                result.Add(slotsCopy);

                return;
            }

            for (int col = 0; col < n; col++)
            {
                int positiveDiagonal = col + row, negativeDiagonal = col - row;
                if (usedColumns.Contains(col)
                    || usedPositiveDiagonals.Contains(positiveDiagonal)
                    || usedNegativeDiagonals.Contains(negativeDiagonal))
                    continue;

                slots[row] = col;
                usedColumns.Add(col);
                usedPositiveDiagonals.Add(positiveDiagonal);
                usedNegativeDiagonals.Add(negativeDiagonal);

                SolveNQueens(n, row + 1, slots, usedColumns, usedPositiveDiagonals, usedNegativeDiagonals, result);

                usedColumns.Remove(col);
                usedPositiveDiagonals.Remove(positiveDiagonal);
                usedNegativeDiagonals.Remove(negativeDiagonal);
            }
        }

        private static int[] _directionsX = { 0, 0, 1, -1 };
        private static int[] _directionsY = { 1, -1, 0, 0 };
        private static char[] _directions = { 'D', 'U', 'R', 'L' };

        private static void FindAllPaths(string[] labyrinth, int row, int col, StringBuilder path, bool[][] visited, List<string> results)
        {
            if (row == labyrinth.Length - 1 && col == labyrinth[^1].Length - 1)
            {
                results.Add(path.ToString());
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int nextRow = row + _directionsY[i], nextCol = col + _directionsX[i];
                if (nextRow < 0 || nextRow >= labyrinth.Length
                    || nextCol < 0 || nextCol >= labyrinth[nextRow].Length
                    || visited[nextRow][nextCol]
                    || labyrinth[nextRow][nextCol] == '*')
                    continue;

                visited[nextRow][nextCol] = true;
                path.Append(_directions[i]);
                
                FindAllPaths(labyrinth, nextRow, nextCol, path, visited, results);
                
                path.Length--;
                visited[nextRow][nextCol] = false;
            }
        }
    }
}
