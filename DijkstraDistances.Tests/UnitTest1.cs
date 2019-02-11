using System.IO;
using System.Linq;
using DijkstraDistances.Graphs;
using NUnit.Framework;

namespace DijkstraDistances.Tests
{
    public class Tests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "TestCases")]
        public void CanLoadGraphs(string inputFile, string outputFile)
        {
            var graph = GraphParser.Parse(inputFile);
            //assert that each line produced a node
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(graph.Count, count);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "TestCases")]
        public void CanCalculatePaths(string inputFile, string outputFile)
        {
            var ids = new[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };
            var distances = File.ReadAllLines(outputFile)
                .First()
                .Split('\t', ' ', ',')
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(int.Parse)
                .ToList();
            var graph = GraphParser.Parse(inputFile);
            var results = Search.CalculateShortestPaths(graph);

            for (int i = 0; i < ids.Length; i++)
            {
                Assert.AreEqual(distances[i], results[ids[i]].Distance);
            }
        }
    }
}