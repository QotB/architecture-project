using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool checkstructrue()
        {
            bool data = false;
            bool text = false; 
            foreach (string l in textBox1.Lines)
            {
                if (l.Length == 0)
                    continue;
                List<string> temp = new List<string>(l.Split(' '));
                if (temp[0] == ".data")
                    data = true;
                if (temp[0] == ".text")
                    text = true; 

            }

            return (data&text); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            if (checkstructrue())
            {
                foreach (string line in textBox1.Lines)
                {
                    if (line.Length == 0||line.Substring(0, 5) == ".data"|| line.Substring(0, 5)==".text")
                        continue;

                    archi.R obj = new R(new List<string>(line.Split(' ')));
                    string mask = obj.getMask();
                    textBox2.AppendText(mask + "\n");
                }
            }
            else
                MessageBox.Show("wala mthazrsh !!");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
