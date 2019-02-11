using System.Collections.Generic;

namespace DijkstraDistances.Graphs
{
    public class Node
    {
        public int Id { get; set; }
        //key is id of other node
        //value is distance to other node
        public Dictionary<int, Edge> Edges { get; set; }

        public Node(int id, Dictionary<int, Edge> edges)
        {
            Id = id;
            Edges = edges;
        }
    }
}