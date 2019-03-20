﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi
{
    public class R
    {
        string mask = ""; 
        public R (List<string> arguments)
        {
            string instruction = arguments[0];
            string reg1 = arguments[1];
            string reg2 = arguments[2];
            string reg3 = arguments[3];
            if (reg1.Last() == ',')
                reg1 = reg1.Substring(0, reg1.Length - 1);
            if (reg2.Last() == ',')
                reg2 = reg2.Substring(0, reg2.Length - 1);
            if (reg3.Last() == ',')
                reg3 = reg3.Substring(0, reg3.Length - 1);
            global temp = new global();
            string r1 = temp.numofreg(reg2), r2 = temp.numofreg(reg3), r3 = temp.numofreg(reg1);
            string fun = getfunct(instruction);
            mask += "000000";
            mask += r1;
            mask += r2;
            mask += r3;
            mask += "00000";
            mask += fun;
        }
        public string getMask()
        {
            return mask;
        }
        public  string getfunct(string instruction)
        {
            global temp=new global(); 
            if (instruction == "add")
                return global.getBinary(32, 6);
            if (instruction == "and")
                return global.getBinary(36, 6);
            if (instruction == "sub")
                return global.getBinary(34, 6);
            if (instruction == "nor")
                return global.getBinary(39, 6);
            if (instruction == "or")
                return global.getBinary(37, 6);
            return global.getBinary(42, 6);
        }

    }
}
