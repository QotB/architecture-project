using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi
{
    class I : AllTypes
    {
        public I(List<string> arguments)
        {
            global temp = new global();
            if (arguments[0] == "lw" || arguments[0] == "sw")
            {
                mask += getfunct(arguments[0]);
                string s = arguments[2], t = "";
                int st = 0;
                for (int i = 0; i < arguments[2].Length; i++)
                    if (arguments[2][i] == '(')
                    {
                        st = i + 1;
                        break;
                    }
                for (; arguments[2][st] != ')'; st++)
                    t += arguments[2][st];
                mask += temp.numofreg(t);
                mask += temp.numofreg(arguments[1]);
                t = "";
                for (int i = 0; i < arguments[2].Length && arguments[2][i] != '('; i++)
                    t += arguments[2][i];
                if (t.Length > 1 && t[1] == 'x')
                    t = t.Substring(2, t.Length - 2);
                int num = Int32.Parse(t, System.Globalization.NumberStyles.HexNumber);
                mask += global.getBinary(num, 16);
            }
            else
            {
                mask += getfunct(arguments[0]);
                mask += temp.numofreg(arguments[2]);
                mask += temp.numofreg(arguments[1]);
                if (arguments[0] == "addi")
                    mask += global.getBinary(int.Parse(arguments[3]), 16);
                else
                    mask += global.label_address[arguments[3]];
            }
        }
        public string getfunct(string instruction)
        {
            global temp = new global();
            if (instruction == "addi")
                return global.getBinary(8, 6);
            if (instruction == "lw")
                return global.getBinary(35, 6);
            if (instruction == "sw")
                return global.getBinary(43, 6);
            if (instruction == "beq")
                return global.getBinary(4, 6);
            return global.getBinary(5, 6);
        }
    }
}
