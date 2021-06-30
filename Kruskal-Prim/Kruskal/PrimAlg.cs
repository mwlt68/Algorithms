using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    public class PrimAlg
    {
        static bool isInclude(Graph graph,int wantedValue)
        {
            foreach (var item in graph.edgeList)
            {
                if (item.destination == wantedValue || item.vertex == wantedValue)
                {
                    return true;
                }
            }
            return false;
        }
        static int getGraphVertexSize(Graph graph)
        {
            int size = 0;
            List<int> visitedList = new List<int>();
            foreach (var item in graph.edgeList)
            {
                foreach (var vis in visitedList)
                {
                    if (vis == item.vertex)
                    {
                        continue;
                    }
                }
                size++;
            }
            return size;
        }
        public static void prim(Graph graph,int wantedValue)
        {
            if (graph.edgeList.Count == 0)
            {
                Console.WriteLine("Grafınızda eleman yok !");
                return;
            }
            if (!isInclude(graph,wantedValue))
            {
                Console.WriteLine("Grafınızda  aradıgınız eleman yok !");
                return;
            }
            List<int> visitedList = new List<int>();
            List<Edge> edgeList = new List<Edge>();
            int size = getGraphVertexSize(graph);
            graph.Sort();
            Graph resultGraph = new Graph(edgeList);
            visitedList.Add(wantedValue);
            for (int i = 0; i < size; i++)
            {
                foreach (var edge in graph.edgeList)
                {
                    foreach (var vis in visitedList.ToList())
                    {
                        if (!KruskalAlg.isVisited(visitedList, edge) && edge.vertex==vis )
                        {
                            resultGraph.edgeList.Add(edge);
                            visitedList.Add(edge.destination);
                        }
                    }
                    
                }
            }
            KruskalAlg.printGraph(resultGraph);
        }
    }
}
