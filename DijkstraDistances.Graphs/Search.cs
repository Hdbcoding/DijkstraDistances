using System.Collections.Generic;
using System.Linq;

namespace DijkstraDistances.Graphs
{
    public static class Search
    {
        public static Dictionary<int, ShortestPathResult> CalculateShortestPaths(Dictionary<int, Node> graph)
        {
            var results = new Dictionary<int, ShortestPathResult>();
            results.Add(1, new ShortestPathResult(0, graph[1], new[]{1}.ToList()));
            //edges leaving processedNodes
            var outgoingEdges = graph[1].Edges.Values.ToList();

            while (results.Count < graph.Count)
            {
                Edge bestEdge = null;
                var bestScore = int.MaxValue;
                foreach (var edge in outgoingEdges)
                {
                    var score = GetScore(edge, results);
                    if (score < bestScore)
                    {
                        bestEdge = edge;
                        bestScore = score;
                    }
                }

                var path = results[bestEdge.Source].Path.ToList();
                path.Add(bestEdge.Destination);
                results.Add(bestEdge.Destination, 
                    new ShortestPathResult(bestScore, graph[bestEdge.Destination], path));
                
                //remove all outgoing edges that reference this element
                outgoingEdges.RemoveAll(n => n.Destination == bestEdge.Destination);
                //add all new outgoing edges from this new member of the result set
                var edgesToAdd = graph[bestEdge.Destination].Edges.Values
                    .Where(n => !results.ContainsKey(n.Destination));
                outgoingEdges.AddRange(edgesToAdd);
            }

            return results;
        }

        private static int GetScore(Edge edge, Dictionary<int, ShortestPathResult> results)
        {
            return results[edge.Source].Distance + edge.Length;
        }
    }
}