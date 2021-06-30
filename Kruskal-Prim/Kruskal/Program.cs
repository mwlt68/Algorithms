using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            int algorithmType; /* 0 = kruskal 1 = prim */
            List<Edge> edgeList = new List<Edge>();
            Graph graph = new Graph(edgeList);
            String v, e, d, s="",t;
            Console.WriteLine("Algoritma tipini seçiniz (0 = kruskal 1 = prim)");
            t = Console.ReadLine();
            algorithmType = Convert.ToInt32(t);
            
            Console.WriteLine("Çıkmak için tepe degerine -1 veriniz.");
            while (true)
            {
                Console.WriteLine("Tepe degerini giriniz");
                v = Console.ReadLine();
                if (Convert.ToInt32(v) == -1)
                {
                    if (algorithmType==1)
                    {
                        Console.WriteLine("Başlangıç degerini giriniz");
                        s = Console.ReadLine();
                    }
                    break;
                }
                Console.WriteLine("Hedef degerini giriniz");
                e = Console.ReadLine();
                Console.WriteLine("Mesafeyi giriniz");
                d = Console.ReadLine();
                graph.edgeList.Add(new Edge(Convert.ToInt32(v), Convert.ToInt32(e), Convert.ToInt32(d)));
                graph.edgeList.Add(new Edge(Convert.ToInt32(e), Convert.ToInt32(v), Convert.ToInt32(d)));
            }
            /*  Hazır degerler satır 62 ikinci parametre değiştir
            graph.edgeList.Add(new Edge(0,1,2));
            graph.edgeList.Add(new Edge(1,0,2));
            graph.edgeList.Add(new Edge(0,3,6));
            graph.edgeList.Add(new Edge(3,0,6));
            graph.edgeList.Add(new Edge(1,2,3));
            graph.edgeList.Add(new Edge(2,1,3));
            graph.edgeList.Add(new Edge(1,3,8));
            graph.edgeList.Add(new Edge(3,1,8));
            graph.edgeList.Add(new Edge(1,4,5));
            graph.edgeList.Add(new Edge(4,1,5));
            graph.edgeList.Add(new Edge(2,4,7));
            graph.edgeList.Add(new Edge(4,2,7));
            graph.edgeList.Add(new Edge(3,4,9));
            graph.edgeList.Add(new Edge(4,3,9));
            int wanderValue = 2;
            */
            if (algorithmType == 0)
                KruskalAlg.kruskal(graph);
            else
                PrimAlg.prim(graph,Convert.ToInt32(s)   /*wanderValue*/    );
            Console.ReadLine();
        }
    }
}
