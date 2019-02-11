namespace DijkstraDistances.Graphs
{
    public class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Length { get; set; }

        public Edge(int source, int destination, int length)
        {
            Source = source;
            Destination = destination;
            Length = length;
        }
    }
}