using System;
using System.Collections.Generic;
using System.IO;

namespace BFS_DFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startDir = Console.ReadLine();
            LayeredDfs(startDir, 1);
        }

        static void Bfs(string startDir)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startDir);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                Console.WriteLine(current);

                foreach (var subDirectory in Directory.EnumerateDirectories(current))
                    queue.Enqueue(subDirectory);
            }
        }

        static void LayeredBfs(string startDir)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startDir);

            int depth = 1;
            while (queue.Count > 0)
            {
                int iterationsCount = queue.Count;
                Console.WriteLine($"Starting the iteration of {iterationsCount} directories at depth #{depth}");

                for (int i = 0; i < iterationsCount; i++)
                {
                    string current = queue.Dequeue();
                    Console.WriteLine(current);

                    foreach (var subDirectory in Directory.EnumerateDirectories(current))
                        queue.Enqueue(subDirectory);
                }

                depth++;
            }
        }

        static void Dfs(string path)
        {
            Console.WriteLine(path);
            foreach (var subDirectory in Directory.EnumerateDirectories(path))
                Dfs(subDirectory);
        }

        static void LayeredDfs(string path, int depth)
        {
            Console.WriteLine($"At depth {depth}: {path}");
            foreach (var subDirectory in Directory.EnumerateDirectories(path))
                LayeredDfs(subDirectory, depth + 1);
        }
    }
}
