using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    
    public class KruskalAlg
    {
        public static void kruskal(Graph graph)
        {
            if (graph.edgeList.Count ==0)
            {
                Console.WriteLine("Grafınızda eleman yok !");
                return;
            }
            List<int> visitedList = new List<int>();
            List<Edge> edgeList = new List<Edge>();
            graph.Sort();
            visitedList.Add(graph.edgeList[0].vertex);
            Graph resultGraph = new Graph(edgeList);
            foreach (var edge in graph.edgeList)
            {
                if (!isVisited(visitedList, edge))
                {
                    resultGraph.edgeList.Add(edge);
                    visitedList.Add(edge.destination);
                }

            }
            printGraph(resultGraph);
        }
        public static bool isVisited(List<int> visitedList,Edge edge)
        {
            foreach (var vis in visitedList)
            {
                if (edge.destination == vis)
                {
                    return true;
                }
            }
            return false;
        }
        public static void printGraph(Graph graph)
        {
            int sumDis = 0;
            Console.WriteLine("\n\n****************************");
            Console.WriteLine("Tepe     Hedef       Mesafe");
            foreach (var edge in graph.edgeList)
            {
                Console.WriteLine(edge.vertex+"\t\t"+edge.destination + "\t\t" +edge.distance);
                sumDis += edge.distance;
            }
            Console.WriteLine("\n\nEn kısa mesafe :"+sumDis);
            Console.WriteLine("\n\n****************************");

        }
    }
}
