using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DijkstraDistances.Graphs
{
    public static class GraphParser
    {
        //parses graph from an input file
        //note - graphs are expected to be undirected, but the array representation is expected to never miss an edge
        //e.g.,
        //  1 2,5   <-- 2 is mentioned as an edge to 1
        //  2 1,5   <-- 1 must be included as an edge to 2
        //the parsing logic will not handle this case:
        //  1 2,5
        //  2       <-- back-edge missing from data
        public static Dictionary<int, Node> Parse(string inputFile)
        {
            var graph = new Dictionary<int, Node>();
            foreach (string line in File.ReadLines(inputFile))
            {
                var values = line.Split('\t', ' ')
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .ToList();
                int id = int.Parse(values[0]);
                values.RemoveAt(0);
                var edges = new Dictionary<int,Edge>();
                var edgePairs = values.Select(n => n
                        .Split(',')
                        .Where(m => !string.IsNullOrWhiteSpace(m))
                        .Select(int.Parse));
                foreach (var pair in edgePairs){
                    var edgeId = pair.First();
                    var length = pair.Last();
                    if (edges.ContainsKey(edgeId)) length = Math.Min(edges[edgeId].Length, length);
                    edges[edgeId] = new Edge(id, edgeId, length);
                }
                var node = new Node(id, edges);
                graph.Add(id, node);
            }
            return graph;
        }
    }
}