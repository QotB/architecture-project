using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi
{
    public class global
    {


        public static Dictionary<string, string> varbleaddressline;
        public static Dictionary<string, List<string> > varbleaddressmemory;
        public static Dictionary<string, string> varbledatatype;
        public static Dictionary<string, List<string>> varablevalue;
        public static Dictionary<string, List<string>> memory_values;
        public static int address_line = 0;
        public static int address_memory = 0;

        public static List<string> split_data(string s)
        {
            List<string> l = new List<string>();
            string a = "";
            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] == ' ' || s[i] == ',' || s[i] == ':' || s[i] == '.')
                {
                    if (a != "" && a != " " && a != ":" && a != ".")
                    {
                        l.Add(a);
                        a = "";
                    }
                    a = "";
                }
                else
                    a += s[i];
            }
            if (a != "" && a != " " && a != ":" && a != ".")
            {
                l.Add(a);
                a = "";
            }
            return l;

        }
        public static string getBinary(int x, int len)
        {
            string s = "";
            while(x != 0)
            {
                if (x % 2 == 0)
                    s += "0";
                if (x % 2 == 1)
                    s += "1";
                x /= 2;
            }
            while (s.Length < len)
                s += '0';
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
        public static void scan_code_seg(string[] code)
        {
            int emp_line = 0, text_start = 0;
            bool text = false;
            for (int i = 0; i < code.Length; i++)
            {
                if (cutter(code[i]).Count == 0)
                {
                    emp_line++;
                    continue;
                }
                if (code[i].Substring(0, 5) == ".data")
                {
                    continue;
                }
                else if (code[i].Substring(0, 5) == ".text")
                {
                    emp_line = 0;
                    text = true;
                    continue;
                }

                if (!text)
                {
                    // data seg 
                }

                else
                {
                    List<string> tmp = cutter(code[i]);
                    if (tmp[0].Last() == ':' || tmp[1] == ":")  // valid label 
                    {
                        if (tmp[0].Last() == ':')
                        {
                            tmp[0] = tmp[0].Substring(0, tmp[0].Length - 1);
                        }
                        int inc = 0;
                        if (tmp.Count <= 2)
                            inc++;
                        label_address[tmp[0]] = getBinary((text_start - emp_line), 26);

                        if (tmp.Count > 2)
                            text_start += 4;
                        else
                            text_start++;
                    }
                    else
                    {
                        // not label 
                        text_start += 4;
                    }
                }
            }
        }


        public string numofreg(string nameofreg)
        {
            if (nameofreg == "$zero")
                return "00000";
            if (nameofreg == "$at")
                return getBinary(01, 5);
            if (nameofreg == "$v0")
                return getBinary(02, 5);
            if (nameofreg == "$v1")
                return getBinary(03, 5);
            if (nameofreg == "$a0")
                return getBinary(04, 5);
            if (nameofreg == "$a1")
                return getBinary(05, 5);
            if (nameofreg == "$a2")
                return getBinary(06, 5);
            if (nameofreg == "$a3")
                return getBinary(07, 5);
            if (nameofreg == "$t0")
                return getBinary(08, 5);
            if (nameofreg == "$t1")
                return getBinary(09, 5);
            if (nameofreg == "$t2")
                return getBinary(10, 5);
            if (nameofreg == "$t3")
                return getBinary(011, 5);
            if (nameofreg == "$t4")
                return getBinary(012, 5);
            if (nameofreg == "$t5")
                return getBinary(013, 5);
            if (nameofreg == "$t6")
                return getBinary(014, 5);
            if (nameofreg == "$t7")
                return getBinary(015, 5);
            if (nameofreg == "$s0")
                return getBinary(016, 5);
            if (nameofreg == "$s1")
                return getBinary(017, 5);
            if (nameofreg == "$s2")
                return getBinary(018, 5);
            if (nameofreg == "$s3")
                return getBinary(019, 5);
            if (nameofreg == "$s4")
                return getBinary(20, 5);
            if (nameofreg == "$s5")
                return getBinary(021, 5);
            if (nameofreg == "$s6")
                return getBinary(022, 5);
            if (nameofreg == "$s7")
                return getBinary(023, 5);
            if (nameofreg == "$t8")
                return getBinary(024, 5);
            if (nameofreg == "$t9")
                return getBinary(025, 5);
            if (nameofreg == "$k0")
                return getBinary(026, 5);
            if (nameofreg == "$k1")
                return getBinary(027, 5);
            if (nameofreg == "$gp")
                return getBinary(028, 5);
            if (nameofreg == "$sp")
                return getBinary(029, 5);
            if (nameofreg == "fp")
                return getBinary(30, 5);
            return getBinary(31, 5);
        }
        // data 
        public static Dictionary<string, string> opcode = new Dictionary<string, string>();
        public static Dictionary<string, string> label_address = new Dictionary<string, string>();
        public static Dictionary<string ,int > choice = new Dictionary<string,int>();
        // functions 
        public static List<string> cutter(string mips_ins)
        {
            List<string> tmp1 = new List<string>();
            string tmp2 = "";
            mips_ins += '#'; // comment , prevent lossing last part  
            for (int i = 0; i < mips_ins.Length; i++)
            {
                if (mips_ins[i] == ' ' || mips_ins[i] == '#' || mips_ins[i] == ',')
                {
                    if (tmp2 == "" || tmp2 == ",")  // not valid 
                    {
                        tmp2 = "";
                        continue;
                    }
                    

                    tmp1.Add(tmp2);
                    tmp2 = "";

                    if (mips_ins[i] == '#')  // could be comment  , or my end 
                    {
                        break;
                    }
                }
                else
                {
                    tmp2 += mips_ins[i];
                }
            }
            return tmp1;
        }



        // fill op code 
        public static void fill_opcode()
        {
            opcode.Add("j", "000010");


            /*
             *  etc.........
             */
        }
       
        public static void init()
        {
            choice["add"] = 0;
            choice["and"] = 0;
            choice["sub"] = 0;
            choice["nor"] = 0;
            choice["or"] = 0;
            choice["slt"] = 0;

            choice["addi"] = 1;
            choice["lw"] = 1;
            choice["sw"] = 1;
            choice["beq"] = 1;
            choice["bne"] = 1;

            choice["j"] = 2;
            varbleaddressline = new Dictionary<string, string>();
            varablevalue = new Dictionary<string, List<string>>();
            varbleaddressmemory = new Dictionary<string, List<string> >();
            varbledatatype = new Dictionary<string, string>();
            memory_values = new Dictionary<string, List<string>>();
        }
    }
}
