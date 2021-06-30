using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    public class Graph
    {
        public List<Edge> edgeList = new List<Edge>();

        public Graph(List<Edge> edgeList)
        {
            this.edgeList = edgeList;
        }

        public void Sort()
        {
            edgeList.Sort();
        }
        
    }
    public class Edge : IComparable<Edge>
    {
        public int vertex,destination,distance;

        public Edge(int vertex, int destination, int distance)
        {
            this.vertex = vertex;
            this.destination = destination;
            this.distance = distance;
        }

        public int CompareTo(Edge other)
        {
            return distance - other.distance;
        }
    }
}
