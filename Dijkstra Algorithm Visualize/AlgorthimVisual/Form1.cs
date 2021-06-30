using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorthimVisual
{
    public partial class Form1 : Form
    {
        List<Button> btns = new List<Button>();
        List<Graph> graphList = null;
        int borderX = 80;
        int borderY = 100;
        List<int> btnTagList = new List<int>();
        int btnConsSize = 50;
        int centerStartX;
        int centerStartY;
        Point cntrPos;
        int[] isEmpty;
        Point lStartPos;
        Point rStartPos;
        Point bStartPos;
        int leftBorder = 0;
        int rightBorder = 0;
        int bottomBorder = 0;
        public Form1()
        {
            graphList = DataReader.getGraphPointToTxt();
            InitializeComponent();
            Invalidate();
            getCenterPosition();
        }
        
        public void getCenterPosition()
        {
            centerStartY = this.Size.Height / 2 - 200;
            centerStartX = this.Size.Width / 2 - 150;
            cntrPos = new Point(centerStartX,centerStartY);
            lStartPos = new Point(50,200);
            rStartPos = new Point(this.Width-200,200);
            bStartPos = new Point(200, this.Height - 150);

            isEmpty = new int[3];
            for (int i = 0; i < 3; i++)
            {
                isEmpty[i] = 0;
            }
        }
        /*
        public List<Graph> getGraphList() {
            try
            {
                return DataReader.getGraphPointToTxt();
            }
            catch (Exception)
            {
                MessageBox.Show("Metin belgesi okunması sırasında hata meydana geldi !");
            }
            return null;
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
          addButtonInForm();
        }
    
 
        public void addButtonInForm()
        {
            int counterGraph=0;
            int counterCon=0;
            foreach (var item in graphList)
            {
                if (!isIncludeSameTag(item.id))
                {
                    addButtonProcess(counterGraph++, Convert.ToString(item.id),true);
                }
            }
            foreach (var item in graphList)
            {
                
                foreach (var con in item.conList)
                {
                    if (!isIncludeSameTag(con.targetId))
                    {
                        addButtonProcess(counterCon++, Convert.ToString(con.targetId),false);
                    }
                }
            }
        }
        public bool isIncludeSameTag(int tag)
        {
            foreach (var target in btnTagList)
            {
                if (tag == target)
                {
                   return true;
                }
            }
            return false;
        }
        public void addButtonProcess(int num,String tag,bool isGraph)
        {
            int tagNo = Convert.ToInt32(tag);
            Button btn = new Button();
            btnTagList.Add(tagNo);
            btn.Text = tag;
            btn.Tag = tag;
            toolTip1.SetToolTip(btn,getToolTip(tagNo));
            btn.Size = new Size(50,50);
            btn.Location =getLocNewTry( num,  isGraph); 
            this.Controls.Add(btn);
            btn.Click += new EventHandler(visualButton_Click); ;
            btns.Add(btn);
        }
        public void visualButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(getToolTip(Convert.ToInt32(btn.Tag)));
        }
        public String getToolTip(int num)
        {
            String str="";
            foreach (var graph in graphList)
            {
                if (graph.id==num)
                {
                    foreach (var con in graph.conList)
                    {
                        str += graph.id + " -> " + con.targetId + " Mesafe=" + con.distance+"\n";
                    }
                }
            }
            return str;
        }
        public Point getRndPointSpecial(int maxX,int maxY, int minX = 100, int minY = 100)
        {
            Random r = new Random();
            return new Point(r.Next(minX, maxX), r.Next(minY, maxY));
        }
        public Point getLocNewTry(int num,bool isGraph)
        {
            if (isGraph == true && num <6)
            {
                switch (num)
                {
                    case 0:
                        return cntrPos;
                        break;
                    case 1:
                        return new Point(cntrPos.X+150,cntrPos.Y);
                        break;
                    case 2:
                        return new Point(cntrPos.X , cntrPos.Y + 130);
                        break;
                    case 3:
                        return new Point(cntrPos.X + 150, cntrPos.Y+130);
                        break;
                    case 4:
                        return new Point(cntrPos.X, cntrPos.Y+270);
                        break;
                    case 5:
                        return new Point(cntrPos.X + 150, cntrPos.Y+270);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Point rPoint;
                if (isEmpty[0] < 4)/*Left is empty*/
                {
                    rPoint=new Point(lStartPos.X, lStartPos.Y + leftBorder);
                    leftBorder += 120;
                    isEmpty[0]++;

                }
                else if (isEmpty[1] < 4) /*Right is empty*/
                {
                    rPoint = new Point(rStartPos.X,rStartPos.Y+rightBorder);
                    rightBorder += 70;
                    isEmpty[1]++;
                }
                else if(isEmpty[2] < 5) /*Bottom is empty*/
                {
                    rPoint= new Point(bStartPos.X +bottomBorder, bStartPos.Y);
                    bottomBorder += 150;
                    isEmpty[2]++;
                }
                else     /*Add Random*/
                {
                    rPoint=  getRndPointSpecial(1200,500);
                }
                return rPoint;
            }
            return getRndPointSpecial(1200, 500);
        }
        

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random r = new Random();
            Pen pen = new Pen(Color.Black, 4);
            pen.EndCap = LineCap.ArrowAnchor;
            pen.StartCap = LineCap.RoundAnchor;
            foreach (var graph in graphList)
            {
                Point gPoint= getBtnLoc(graph.id);
                foreach (var con in graph.conList)
                {
                    Point cPoint = getBtnLoc(con.targetId);
                    int x1 = gPoint.X + getRndNum();
                    int y1 = gPoint.Y+getRndNum();
                    Point targetPoint = getSuitablePosForBtnEdge(gPoint, cPoint);
                    int x2 = targetPoint.X;
                    int y2 = targetPoint.Y;
                    pen.Color=Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                    e.Graphics.DrawLine(pen,x1, y1, x2,y2);
                }
            }
            
        }
        public Point getSuitablePosForBtnEdge(Point start,Point stop)
        {
            int distance = 70;
            if (start.Y-stop.Y > distance)
            {
                return new Point(stop.X + getRndNum(), stop.Y + btnConsSize );
            }
            else if (stop.Y-start.Y > distance)
            {
                return new Point(stop.X + getRndNum(), stop.Y );
            }
            else
            {
                if (stop.X < start.X)
                {
                    return new Point(stop.X+btnConsSize , stop.Y + getRndNum());
                }
                else
                {
                    return new Point(stop.X , stop.Y + getRndNum());
                }
            }
        }
        public Point getBtnLoc(int id)
        {
            String tag = Convert.ToString(id);
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Button )
                {
                    Button btn = this.Controls[i] as Button;
                    //((Button)(this.Controls[i].Tag))
                    if (btn.Tag.Equals(tag) == true)
                    {
                        return this.Controls[i].Location;
                    }
                }
            }
            return new Point(0, 0);
        }
        public Point getRndPoint(int min=0,int max=50)
        {
            Random r = new Random();
            return new Point(r.Next(min, max), r.Next(min, max));
        }
        public int getRndNum(int min = 0, int max = 50)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
        public bool isInclude(int a)
        {
            foreach (var item in btnTagList)
            {
                if (item ==a )
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphList == null)
            {
                return;
            }
            try
            {
                if (isInclude(Convert.ToInt32(textBox1.Text))==false)
                {
                    MessageBox.Show("Bu sayı graph listesine ekli degil !");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu alana sadece sayı giriniz !");
                return;
            }
            int size= btnTagList.Count;
            int[] graphArray = new int[size];
            int[,]array = new int[size,size] ;
            for (int i = 0; i < size; i++)
            {
                graphArray[i] = btnTagList.ElementAt(i);
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i,j] = 0;
                }
            }
           
            foreach (var graph in graphList)
            {
                int adresI = 0, adresJ = 0;
                for (int i = 0; i < size; i++)
                {
                    if (graphArray[i] == graph.id)
                    {
                        adresI = i;
                    }
                }
                foreach (var con in graph.conList)
                {

                    for (int i = 0; i < size; i++)
                    {
                        if (graphArray[i] == con.targetId)
                        {
                            adresJ = i;
                        }
                    }
                    array[adresI,adresJ]= con.distance;
                }
            }
            int selectedId=0;
            for (int i = 0; i < size; i++)
            {
                if (Convert.ToInt32(textBox1.Text)==graphArray[i])
                {
                    selectedId = i;
                }
            }
            GFG t = new GFG(size,btns);
            int [] resultDist=t.dijkstra(array,selectedId );
            Form2 frm2 = new Form2(resultDist, graphArray, Convert.ToInt32(textBox1.Text));
            frm2.ShowDialog();
            
        }
    }
}
