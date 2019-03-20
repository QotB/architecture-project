using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi
{
    public class global
    {
        public  string getBinary(int x)
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
            while (s.Length < 5)
                s += '0';
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
        public  string numofreg(string nameofreg)
        {
            if (nameofreg == "$zero")
                return "00000";
            if (nameofreg == "$at")
                return getBinary(01);
            if (nameofreg == "$v0")
                return getBinary(02);
            if (nameofreg == "$v1")
                return getBinary(03);
            if (nameofreg == "$a0")
                return getBinary(04);
            if (nameofreg == "$a1")
                return getBinary(05);
            if (nameofreg == "$a2")
                return getBinary(06);
            if (nameofreg == "$a3")
                return getBinary(07);
            if (nameofreg == "$t0")
                return getBinary(08);
            if (nameofreg == "$t1")
                return getBinary(09);
            if (nameofreg == "$t2")
                return getBinary(10);
            if (nameofreg == "$t3")
                return getBinary(011);
            if (nameofreg == "$t4")
                return getBinary(012);
            if (nameofreg == "$t5")
                return getBinary(013);
            if (nameofreg == "$t6")
                return getBinary(014);
            if (nameofreg == "$t7")
                return getBinary(015);
            if (nameofreg == "$s0")
                return getBinary(016);
            if (nameofreg == "$s1")
                return getBinary(017);
            if (nameofreg == "$s2")
                return getBinary(018);
            if (nameofreg == "$s3")
                return getBinary(019);
            if (nameofreg == "$s4")
                return getBinary(20);
            if (nameofreg == "$s5")
                return getBinary(021);
            if (nameofreg == "$s6")
                return getBinary(022);
            if (nameofreg == "$s7")
                return getBinary(023);
            if (nameofreg == "$t8")
                return getBinary(024);
            if (nameofreg == "$t9")
                return getBinary(025);
            if (nameofreg == "$k0")
                return getBinary(026);
            if (nameofreg == "$k1")
                return getBinary(027);
            if (nameofreg == "$gp")
                return getBinary(028);
            if (nameofreg == "$sp")
                return getBinary(029);
            if (nameofreg == "fp")
                return getBinary(30);
            return getBinary(31);
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

        }
    }
}
