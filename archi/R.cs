using System;
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
            string r1 = global.numofreg(reg2), r2 = global.numofreg(reg3), r3 = global.numofreg(reg1);
            string fun = global.getfunct(instruction);
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

    }
}
