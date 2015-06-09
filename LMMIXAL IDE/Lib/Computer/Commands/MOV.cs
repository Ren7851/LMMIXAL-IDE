using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Computer.Commands
{
    public class MOV:Command
    {
        public MOV(string from, string to) 
        {
            args[0] = to;
            args[1] = from;
            arity = 2;
        }

        public override string Type() 
        {
            return "MOV";
        }

        public override string Syntax
        {
            get
            {
                return "MOV [any_type]from [any_type]to";
            }
        }

        public override string Description
        {
            get
            {
                return "to = from";
            }
        }

        public static void Mov(string from , string to, Computer computer) 
        {
             Utils.Utils.PutInAddress(to, computer, Utils.Utils.ParseAddress(from, computer));
        }

        public override void Execution(Computer computer)
        {
            if (args[0].IndexOf("[") == -1)
            {
                //MessageBox.Show(Utils.Utils.NormaliseAddress(args[0], computer));
                Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.ParseAddress(args[1], computer));
            }
            else 
            {
                Byte bt = Utils.Utils.ParseByteAddress(args[1], computer);
                Utils.Utils.PutInByteAddress(args[0], computer, Utils.Utils.ParseByteAddress(args[1], computer));
            }
        }
    }
}
