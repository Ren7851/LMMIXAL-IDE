using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public abstract class LongArithmeticCommand : Command
    {
        public LongArithmeticCommand() { }

        public LongArithmeticCommand(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            arity = 2;
        }

        public override string Type()
        {
            return "long arithmetic command";
        }

        public abstract long operation(long operand1, long operand2);

        public override void Execution(Computer computer)
        {
            long operand1 = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[0], computer));
            long operand2 = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[1], computer));
            long res = operation(operand1, operand2);
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.LongToOcto(res));
        }
    }
}
