using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorthimVisual
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class GFG
    {
        List<Button> btns = null;
        int V ;
        public GFG(int v,List<Button> btns)
        {
            this.btns = btns;
            V = v;
        }
        // A utility function to find the 
        // vertex with minimum distance 
        // value, from the set of vertices 
        // not yet included in shortest 
        // path tree 
        int minDistance(int[] dist,
                        bool[] sptSet,int src)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }

            return min_index;
        }

        // A utility function to print 
        // the constructed distance array 
        void printSolution(int[] dist, int n)
        {
            Console.Write("Vertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        // Funtion that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation 
        public int[] dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i] 
                                     // will hold the shortest 
                                     // distance from src to i 

            // sptSet[i] will true if vertex 
            // i is included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            bool[] sptSet = new bool[V];

            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. u is always equal to 
                // src in first iteration. 
                int u = minDistance(dist, sptSet,src);

                // Mark the picked vertex as processed 
                sptSet[u] = true;

                // Update dist value of the adjacent 
                // vertices of the picked vertex. 

                for (int v = 0; v < V; v++)
                {


                    // Update dist[v] only if is not in 
                    // sptSet, there is an edge from u 
                    // to v, and total weight of path 
                    // from src to v through u is smaller 
                    // than current value of dist[v] 
                    if (!sptSet[v] && graph[u, v] != 0 &&
                         dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u,v];

                }
            }
            List<Distance> distList = new List<Distance>();
            for (int i = 0; i < dist.Length; i++)
            {
                distList.Add(new Distance(Convert.ToInt32(btns.ElementAt(i).Tag),dist[i]));
            }
            paintButton(distList, src);
            // print the constructed distance array 
            return dist;
        }
        public bool isVisited(int[] visited,int index)
        {
            for (int l = 0; l < visited.Length; l++)
            {
                if (visited[l]==index)
                {
                    return true;
                }
            }
            return false;
        }
        public void paintButton(List<Distance> distList ,int src)
        {
            int red = 0, blue = 0, green = 255;
            int rise = 25;
            List<Distance> orderDistList = new List<Distance>(); 
            int[] visited = new int[distList.Count];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = -1;
            }
            int minIndex=0, counter=0,biggestIndex=0;
            foreach (var item in distList)
            {
                if (distList.ElementAt(biggestIndex).distance < item.distance)
                {
                    biggestIndex = distList.IndexOf(item);
                }
            }
            for (int i = 0; i < distList.Count; i++)
            {
                minIndex = biggestIndex;
                for (int j = 0; j < distList.Count; j++)
                {
                    if (distList[j].distance <= distList[minIndex].distance && isVisited(visited,distList[j].btnNum)==false)
                    {
                        minIndex = j;
                    }
                }
                visited[counter++] = distList[minIndex].btnNum;
                orderDistList.Add(distList.ElementAt(minIndex));

            }
            foreach (var item in orderDistList)
            {
                if (item.distance==int.MaxValue)
                {
                    btns.ElementAt(distList.IndexOf(item)).BackColor = Color.Red;
                    continue;
                }
                
                btns.ElementAt(distList.IndexOf(item)).BackColor = Color.FromArgb(red, green, blue);
                int temp = distList.IndexOf(item);
                int tempBefore=0;
                if (orderDistList.IndexOf(item) < orderDistList.Count)
                    tempBefore = distList.IndexOf(orderDistList.ElementAt(orderDistList.IndexOf(item) +1));
                if ( distList.ElementAt(temp).distance == distList.ElementAt(tempBefore).distance)
                {
                    continue;
                }
                if (green > 120)
                {
                    green -= rise;
                }
                else if (blue == 0)
                {
                    blue = 120;
                }
                else if (blue != 0 && blue < 255)
                {
                    blue += rise;

                }
                else
                {
                    continue;
                }
            }
            btns.ElementAt(src).BackColor = Color.Orange;
        }
    }
}
