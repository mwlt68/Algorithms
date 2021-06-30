using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorthimVisual
{
    class Graph
    {
        public int id;
        public List<Con> conList;

        public Graph(int id, List<Con> conList)
        {
            this.id = id;
            this.conList = conList;
        }
    }
    class Con
    {
        public int targetId;
        public int distance;

        public Con(int targetId, int distance)
        {
            this.targetId = targetId;
            this.distance = distance;
        }
    }
    class Splitter
    {
        public int id;
        public int targetId;
        public int distance;

        public Splitter(int id, int targetId, int distance)
        {
            this.id = id;
            this.targetId = targetId;
            this.distance = distance;
        }
    }
}
