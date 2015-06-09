using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If
{
    public class DMORE : Command
    {
        public DMORE(string arg1, string arg2, string res)
        {
            args[0] = arg1;
            args[1] = arg2;
            args[2] = res;
            arity = 3;
            octoArgs.Add(0);
            octoArgs.Add(1);
            octoArgs.Add(2);
        }


        public override string Syntax
        {
            get
            {
                return "DMORE [double]arg1 [double]arg2 [bool]res";
            }
        }

        public override string Description
        {
            get
            {
                return "bool =   arg > arg2";
            }
        }

        public override string Type()
        {
            return "DMORE";
        }

        public override void Execution(Computer computer)
        {
            double operand1 = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[0], computer));
            double operand2 = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[1], computer));
            long boolValue = operand1 > operand2 ? Utils.Utils.OctoToLong(new OctoByte("FFFFFFFFFFFFFFFF")) : 0;
            Utils.Utils.PutInAddress(args[2], computer, Utils.Utils.LongToOcto(boolValue));
        }
    }
}
