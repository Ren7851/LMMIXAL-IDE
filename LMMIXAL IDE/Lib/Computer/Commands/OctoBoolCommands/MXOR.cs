using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.OctoBoolCommands
{
    public class MXOR:MatrixCommand
    {
        public MXOR(string res, string operand1, string operand2):base(res, operand1, operand2)
        {
        }

        public override string Syntax
        {
            get
            {
                return "MXOR [octo]res [octo]arg1 [octo]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "res = arg1 mxor arg2";
            }
        }

        public override bool TopOperation(bool operand1, bool operand2)
        {
            return operand1 ^ operand2;
        }

        public override bool BottomOperation(bool operand1, bool operand2)
        {
            return operand1 & operand2;
        }

        public override string Type()
        {
            return "MXOR";
        }
    }
}
