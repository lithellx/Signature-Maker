using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*AOB*/
            string AOB = " " + textBox1.Text;
            /*AOB*/

            int[] maskArr = new int[255];
            int maskVal = 0;
            /*Signature*/

            string Signature = AOB.Replace(" ", @"\x");
            for (int i = 22; i < Signature.Length; i++) 
            {
                char signatureChar = Signature[i];
                if(signatureChar == '?')
                {
                    maskArr[maskVal] = (i/4)+1;
                    maskVal++;
                }
            }

            Signature = Signature.Replace("??", "00");
            textBox2.Text = Signature;
            /*Signature*/

            /* Mask*/
            string MaskMaker = AOB.Replace(" ", "");
            int m = MaskMaker.Length / 2;
            string Mask;
            for (Mask = ""; Mask.Length < m; Mask += "x")
            {
                Mask += "x";
            }

            for (int i = 0; i < Mask.Length; i++)
            {
                var maskBuilder = new StringBuilder(Mask);
                maskBuilder.Remove(maskArr[i], 1);
                maskBuilder.Insert(maskArr[i], "?");
                Mask = maskBuilder.ToString();
            }

            var maskResult = new StringBuilder(Mask);
            maskResult.Remove(0, 1);
            Mask = maskResult.ToString();
            textBox3.Text = Mask;

            /* Mask*/
        }
    }
}
