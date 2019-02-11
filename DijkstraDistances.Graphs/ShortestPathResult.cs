using System.Collections.Generic;

namespace DijkstraDistances.Graphs
{
    public class ShortestPathResult
    {
        public int Distance { get; set; }
        public Node Node { get; set; }
        public List<int> Path { get; set; }

        public ShortestPathResult(int distance, Node node, List<int> path)
        {
            Distance = distance;
            Node = node;
            Path = path;
        }
    }
}