using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class LMORE : Command
    {
        public LMORE(string arg1, string arg2, string res)
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
                return "LMORE [long]arg1 [long]arg2 [bool]res";
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
            return "LMORE";
        }

        public override void Execution(Computer computer)
        {
            long operand1 = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[0], computer));
            long operand2 = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[1], computer));
            long boolValue = operand1 > operand2 ? Utils.Utils.OctoToLong(new OctoByte("FFFFFFFFFFFFFFFF")) : 0;
            Utils.Utils.PutInAddress(args[2], computer, Utils.Utils.LongToOcto(boolValue));
        }
    }
}
