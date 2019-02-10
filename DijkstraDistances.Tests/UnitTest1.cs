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
            var graph = GraphParser.ParseGraph(inputFile);
            //assert that each line produced a node
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(graph.Count, count);

            //Assert that all edges are reflected
            foreach (var node in graph.Values){
                foreach (var edge in node.Edges){
                    Assert.AreEqual(edge.Value, graph[edge.Key].Edges[node.Id]);
                }
            }
        }
    }
}