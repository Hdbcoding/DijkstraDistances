using System;
using DijkstraDistances.Graphs;

namespace DijkstraDistances.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = GraphParser.Parse("dijkstraData.txt");
            var results = Search.CalculateShortestPaths(graph);

            var ids = new[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };
            foreach (var id in ids)
            {
                Console.WriteLine($"id: {id}, distance: {results[id].Distance}");
            }

            Console.ReadLine();
        }
    }
}
