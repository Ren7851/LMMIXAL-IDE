using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class INC : Command
    {
        public INC(string operand1)
        {
            args[0] = operand1;
            arity = 1;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "INC [long]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg++";
            }
        }


        public override string Type()
        {
            return "INC";
        }

        public override void Execution(Computer computer)
        {
            OctoByte operand = Utils.Utils.ParseAddress(args[0], computer);
            long value = Utils.Utils.OctoToLong(operand);
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.LongToOcto(value + 1));
        }
    }
}
