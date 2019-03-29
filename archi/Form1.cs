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
            global.address_line = 0 ;
            textBox2.Clear();
            if (checkstructrue())
            {
                // check on space comma 
                bool waslnaliidata = false; 

                foreach (string line in textBox1.Lines)
                {
                    
                   
                    if (line.Length == 0||line.Substring(0, 5) == ".data"|| line.Substring(0, 5)==".text" )
                        continue;
                    if (line.Substring(0, 5) == ".text")
                    {
                        waslnaliidata = true;
                    }
                    List<string> l;
                    if (!waslnaliidata)
                    {
                        l = global.split_data(line);
                        string varname=l[0];
                        global.varbleaddressline[varname] = global.address_line.ToString();
                      //  global.varbleaddressmemory[varname] = global.address_memory.ToString();
                        global.varbledatatype[varname] = l[1];
                        global.varablevalue[varname] = new List<string>();
                        global.memory_values[varname] = new List<string>(); 
                        for (int i = 2; i < l.Count ; i++)
                        {
                            global.varablevalue[varname].Add(l[i]);
                        }
                        if (l[1] == "word")
                        {
                            for (int i = 2; i<l.Count; i++)
                            {
                                int ii = Convert.ToInt32(l[i]);
                                string temp = global.getBinary(ii, 32);
                                global.memory_values[varname].Add(temp);
                            }
                            global.address_memory += 8 * (l.Count - 2);
                        }
                        else if (l[1] == "space")
                        {
                            int temp = Convert.ToInt32(l[2]);
                            for (int i = 0; i < temp; i++)
                            {
                                string tmp = "" ;
                                for(int j=0 ; j<32 ; j++)
                                    tmp += "X";
                                global.memory_values[varname].Add(tmp);
                            }
                            temp *= 4;
                            global.address_memory += temp;
                        }
                        global.address_line++;
                        foreach (string i in global.memory_values[varname])
                           {
                               MessageBox.Show(i + " " + i.Length.ToString());

                           }
                        continue; 
                    }
                    else
                        l = global.cutter(line); 
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
                        I obj = new I(l);
                        string mask = obj.getMask();
                        textBox2.AppendText(mask + '\n');
                    }
                }
            }
            else
                MessageBox.Show("wala mthazrsh !!");

            foreach(string i in global.memory_values.Keys)
                MessageBox.Show(i + " AAA ");
            
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
