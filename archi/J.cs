using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi
{
    class J
    {
        static string machine_code = "";   // who can access this ???!!!******

        public static void convertor(List <string> cutted_mips_ins)
        {
            machine_code = "";
            // call the cutter better than the 
            string command = cutted_mips_ins[0];
            string label = cutted_mips_ins[1];

            // get opcode 
            machine_code += global.opcode[command];

            // get label address
            //machine_code += global.label_address[label];

            return;
        }

        public static string get_machine_code()
        {
            return machine_code;
        }
    }
}
