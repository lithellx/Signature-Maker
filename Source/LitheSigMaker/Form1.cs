using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitheSigMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*AOB*/
            string AOB = " " + textBox1.Text;
            /*AOB*/

            /*Signature*/
            string Signature = AOB.Replace(" ", @"\x");
            textBox2.Text = Signature;
            /*Signature*/

            /* Mask*/
            string MaskMaker = AOB.Replace(" ", "");
            int m = MaskMaker.Length / 2;
            for (string Mask = ""; Mask.Length < m; Mask+="x")
            {
                textBox3.Text = Mask + "x";
            }
            /* Mask*/

        }
    }
}
