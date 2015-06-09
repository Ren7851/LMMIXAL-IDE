using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If
{
    public class BMORE:Command
    {
        public BMORE(string arg1, string arg2, string res)
        {
            args[0] = arg1;
            args[1] = arg2;
            args[2] = res;
            arity = 3;
            byteArgs.Add(0);
            byteArgs.Add(1);
            octoArgs.Add(2);
        }

        public override string Syntax
        {
            get
            {
                return "BMORE [byte]arg1 [byte]arg2 [bool]res";
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
            return "BMORE";
        }

        public override void Execution(Computer computer)
        {
            sbyte operand1 = (sbyte)Utils.Utils.ParseByteAddress(args[0], computer).Value(Format.TwosComplement);
            sbyte operand2 = (sbyte)Utils.Utils.ParseByteAddress(args[1], computer).Value(Format.TwosComplement);
            long boolValue = operand1 > operand2 ? Utils.Utils.OctoToLong(new OctoByte("FFFFFFFFFFFFFFFF")) : 0;
            Utils.Utils.PutInAddress(args[2], computer, Utils.Utils.LongToOcto(boolValue));
        }
    }
}
