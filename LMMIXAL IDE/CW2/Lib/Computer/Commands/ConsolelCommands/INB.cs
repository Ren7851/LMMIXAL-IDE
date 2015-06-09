using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class INB:Command
    {
        public INB(){}

        public INB(string address) 
        {
            arity = 1;
            args[0] = address;
            byteArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "INB [byte]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = read()";
            }
        }

        public override string Type()
        {
            return "INB";
        }

        public void SetValue(string input)
        {
            args[1] = input;
        }


        public override void Execution(Computer computer)
        {
            sbyte value = sbyte.Parse(args[1]);
            MessageBox.Show(value+"");
            Utils.Utils.PutInByteAddress(args[0], computer, new Byte(value));
        }
    }
}
