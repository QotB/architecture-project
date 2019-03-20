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
                // check on space comma 
                foreach (string line in textBox1.Lines)
                {
                    if (line.Length == 0||line.Substring(0, 5) == ".data"|| line.Substring(0, 5)==".text" )
                        continue;
                    List<string> l = global.cutter(line);
                    foreach(string s in l)
                        MessageBox.Show(s);
                    if (global.choice[l[0]] == 0)
                    {
                        archi.R obj = new R(l);
                        string mask = obj.getMask();
                        textBox2.AppendText(mask + "\n");
                    }
                    else if (global.choice[l[0]] == 2)
                    {
                        J.convertor(l);
                        string mask = J.get_machine_code();
                        textBox2.AppendText(mask + "\n");
                    }
                    else
                    {
                        //heshm
                    }
                }
            }
            else
                MessageBox.Show("wala mthazrsh !!");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            global.fill_opcode();
            global.init();
        }
    }
}
