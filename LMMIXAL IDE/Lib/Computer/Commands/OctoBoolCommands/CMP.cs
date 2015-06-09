using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.OctoBoolCommands
{
    public class CMP:Command
    {
        public CMP() { }

        public CMP(string res, string operand1, string operand2)
        {
            args[0] = res;
            args[1] = operand1;
            args[2] = operand2;
            OctoArgs.Add(0);
            OctoArgs.Add(1);
            OctoArgs.Add(2);
            arity = 3;
        }

        public override string Type()
        {
            return "CMP";
        }

        public override void Execution(Computer computer)
        {
            long operand1 = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[1], computer));
            long operand2 = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[2], computer));
            long res = 0;
            
            if(operand1 > operand2)
            {
                res = 1;
            }

            if (operand1 < operand2)
            {
                res = -1;
            }

            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.LongToOcto(res));
        }

        public override string Syntax
        {
            get
            {
                return "CMP [octo]res [octo]arg1 [octo]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "res = [arg1-arg2] - [arg2-arg1]";
            }
        }


    }
}
