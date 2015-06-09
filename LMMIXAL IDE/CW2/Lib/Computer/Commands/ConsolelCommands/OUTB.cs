using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class OUTB : Command
    {
        public OUTB(string address)
        {
            args[0] = address;
            arity = 1;
            byteArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "OUTB [byte]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "write(arg)";
            }
        }

        public override string Type()
        {
            return "OUTB";
        }

        public override void Execution(Computer computer)
        {
            //MessageBox.Show(args[0] + " " + Utils.Utils.ParseByteAddress(args[0], computer).HexString);
            computer.console.Text += Utils.Utils.ParseByteAddress(args[0], computer).Value(Format.TwosComplement);
        }
    }
}
