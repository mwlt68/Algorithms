using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorthimVisual
{
    public partial class Form2 : Form
    {
        int[] disArray =null;
        int []graphArray=null;
        int target=0;
        public Form2(int[] disArray,int[] graphArray,int target)
        {
            InitializeComponent();
            this.disArray = disArray;
            this.graphArray = graphArray;
            this.target =target;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            creater();
        }
        public void creater()
        {
            if (disArray== null)
            {
                return;
            }
            label1.Text = target + " için minimum uzaklık tablosu";
            for (int i = 0; i < graphArray.Count(); i++)
            {
                dataGridView1.Rows.Add(graphArray[i], disArray[i]);
            }
        }
    }
}
