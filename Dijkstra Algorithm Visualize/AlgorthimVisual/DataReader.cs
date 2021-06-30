using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorthimVisual
{
    class DataReader
    {
        public static List<Graph> getGraphPointToTxt()
        {
            List<Graph> graphList = new List<Graph>();
            List<Con> conList = null;
            List<Splitter> splitList = new List<Splitter>();
            int lineSize = 0;
            try
            {
                
                    System.IO.StreamReader file =
                    new System.IO.StreamReader("a.txt");
                    String line;
                    while ((line = file.ReadLine()) != null)
                    {
                         String[] linePart = line.Split(',');
                         splitList.Add(new Splitter(strConInt(linePart[0]), strConInt(linePart[1]), strConInt(linePart[2])));
                        lineSize++;
                    }

                
            }
            catch (IOException e)
            {
                MessageBox.Show("Dosya okuma sırasında hata oluştu !");
                Console.WriteLine(e.Message);
            }
            List<int> visited = new List<int>();
            foreach (var item in splitList.ToList())
            {
                if (isVisited(visited,item.id))
                {
                    continue;
                }
                conList= new List<Con>();
                conList.Add(new Con(item.targetId, item.distance));
                for (int i =splitList.IndexOf(item)+1; i < splitList.Count; i++)
                {
                    if (true)
                    {
                        if (item.id == splitList[i].id)
                        {
                            conList.Add(new Con(splitList[i].targetId, splitList[i].distance));
                        }
                    }
                    else
                    {

                    }
                }
                graphList.Add(new Graph(item.id, conList));
                visited.Add(item.id);
            }
            return graphList;
        }

        static int  strConInt(String str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                MessageBox.Show("Yazı sayıya dönüştürürken hata meydana geldi !");
                return 0;
            }
        }
        public static bool isVisited(List<int> visited, int id)
        {
            foreach (var vis in visited)
            {
                if (vis == id)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
