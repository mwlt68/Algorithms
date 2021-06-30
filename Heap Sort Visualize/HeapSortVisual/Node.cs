using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapSortVisual
{
    public class Node:Button
    {
        public int value, id;
        public bool isComplate = false;
        public Node leftNode, rightNode;
        public Node(Form1 frm,int id,int value,Size size,Point pos)
        {
            this.Size = size;
            this.Location = pos;
            frm.Controls.Add(this);
            this.id = id;
            this.value = value;
            this.Text = value.ToString();
        }
    }
}