using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Timer = System.Windows.Forms.Timer;

namespace HeapSortVisual
{
    public partial class Form1 : Form
    {
        Size nodeSize =new  Size(70, 50);
        Point nodesSpacing =new Point(100,50);
        public static bool heapifyFuncActive = false;
        public int[] tempArray;
        public List<Node> nodes = new List<Node>();
         List<SwapValue> swapValuess = new List<SwapValue>();
        int topPadding = 20;
        int treeStageCounter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Create array
            String[] strList = textBox1.Text.Split(',');
            List<Int32> intList = new List<int>(); 
            int[] array;
            int counter = 0;
            foreach (var str in strList)
            {
                if (!(str == "" || str == null))
                {
                    intList.Add(Convert.ToInt32(str));
                }
            }
            array = new int[intList.Count];
            foreach (var item in intList)
            {
                array[counter++] =item;
            }
            tempArray = array;

            // deciding  UI visiable condition 

            Form1ItemVisiable(false);

            // The function that draw  elements of array

            drawNodes();

            startHeap();

            // this isn`t important
            label4.Text = (swapValuess.Count - treeStageCounter - 1).ToString();

        }
        public void writeInfoPanel(int[]arr,int max,int i,int left,int right,int swapI,int swapJ)
        {
            label4.Text = (swapValuess.Count - treeStageCounter-1).ToString();
            label8.Text = i.ToString();
            label9.Text = left.ToString();
            label10.Text= right.ToString();
            label13.Text= max.ToString();
            label11.Text = arr[swapI].ToString();
            label12.Text = arr[swapJ].ToString();
            nodes[swapI].BackColor = Color.Tomato;
            nodes[swapJ].BackColor = Color.FromArgb(255,128, 0);
        }

        

        public void startHeap()
        {
            HeapSort ob = new HeapSort(this, tempArray);
            swapValuess=ob.swapValues;
        }
        public void Form1ItemVisiable(bool vis)
        {
            button3.Visible = true;
            label4.Visible = true;
            label15.Visible = true;
            label1.Visible = vis;
            button1.Visible = vis;
            textBox1.Visible = vis;
        }

        public void drawNodes()
        {
            int counter = 0;
            int nodePosX, nodePosY;
            if (tempArray != null)
            {
                removeOldNodes();
                nodeSize = new Size(70, 50);
                nodesSpacing = new Point(100, 50);
                for (int i = 0; i < tempArray.Length; i++)
                {
                    int left = 2 * i + 1;
                    int right = 2 * i + 2;
                    int subElementCount = (int)(Math.Pow(2, counter + 1));
                    if (i == 0)
                    {
                        nodePosX = ((this.Width) / 2) - (nodeSize.Width / 2);
                        nodePosY = counter * nodeSize.Height+topPadding;
                        Node rootNode = new Node(this, i, tempArray[i], nodeSize, new Point(nodePosX, nodePosY));
                        nodes.Add(rootNode);
                    }
                    Node mainNode = nodes[i];
                    int spaceOfNode = ((this.Width + Width / 10) - (subElementCount * mainNode.Width)) / (subElementCount + 1);
                    if (tempArray.Length > left)
                    {
                        nodePosX = (mainNode.Location.X + (mainNode.Size.Width / 2)) - (spaceOfNode / (8/3))-(mainNode.Size.Width);
                        nodePosY = (2*counter+1) * (nodeSize.Height + topPadding);
                        Node leftNode = new Node(this, left, tempArray[left], nodeSize, new Point(nodePosX, nodePosY));
                        mainNode.leftNode = leftNode;
                        nodes.Add(leftNode);
                    }
                    if (tempArray.Length > right)
                    {
                        nodePosX = (mainNode.Location.X + (mainNode.Size.Width / 2)) + (spaceOfNode / (8/3));
                        nodePosY = (2*counter+1) *( nodeSize.Height + topPadding);
                        Node rightNode = new Node(this, right, tempArray[right], nodeSize, new Point(nodePosX, nodePosY));
                        nodes.Add(rightNode);
                        mainNode.rightNode = rightNode;
                    }
                    if (calculateNodeGeneration( counter) == i )
                    {
                        counter++;
                        {
                            nodeSize.Width -= nodeSize.Width / 5;
                           nodeSize.Height -= nodeSize.Height / 10;
                        }
                    }
                }
            }
        }

        public int calculateNodeGeneration(int counter)
        {
            int sum = 0;
            for (int i = 0; i <= counter; i++)
            {
                sum += (int)Math.Pow(2, i);
            }
            return sum - 1;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            if (tempArray!= null)
            {
                Pen pen = new Pen(Color.Aqua,3);
                foreach (var node in nodes)
                {
                    pen.Color = Color.FromArgb(rnd.Next(100,250), rnd.Next(100, 250), rnd.Next(100, 250));
                    if (node.leftNode!=null)
                    {
                        Point nodePos = new Point(node.Location.X,node.Location.Y+node.Height);
                        Point leftPos = new Point(node.leftNode.Location.X+node.Width,node.leftNode.Location.Y);
                        e.Graphics.DrawLine(pen,nodePos, leftPos);
                    }
                    if (node.rightNode!=null)
                    {
                        Point nodePos = new Point(node.Location.X + node.Width, node.Location.Y + node.Height);
                        e.Graphics.DrawLine(pen,nodePos,node.rightNode.Location);
                    }
                }
            }
        }
        private void Form1_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            removeOldNodes();
            drawNodes();
        }
        public void removeOldNodes()
        {
            // Former nodes removed for draw new nodes 
            foreach (var node in nodes.ToArray())
            {
                this.Controls.Remove(node);
                nodes.Remove(node);
            }
            // Paint-Function that paints attached nodes
            this.Invalidate();
        }

        private void Button3_Click(object sender, EventArgs e) 
            // Continue Button that every step proceed
        {
            if (panel1.Visible == false)
                panel1.Visible = true;
            SwapValue swap = swapValuess[treeStageCounter];
            tempArray = swap.array;
            drawNodes();
            writeInfoPanel(tempArray,swap.max,swap.index,swap.left,swap.right,swap.swapI,swap.swapJ);
            treeStageCounter++;
            if (treeStageCounter==swapValuess.Count)
            {
                button3.Visible = false;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
