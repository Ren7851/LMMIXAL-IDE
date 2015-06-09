using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class NANDO : OctoBoolCommand
    {
        public NANDO(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            octoArgs.Add(0);
            octoArgs.Add(1);
            arity = 2;
        }

        public override string Syntax
        {
            get
            {
                return "NAND [bool]arg1 [bool]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "arg1 = !(arg1 & arg2)";
            }
        }

        public override bool operation(bool operand1, bool operand2)
        {
            return !(operand1 & operand2);
        }

        public override string Type()
        {
            return "NAND";
        }
    }
}
