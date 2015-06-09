using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ConditionActions
{
    public abstract class CondElseDoNothing:ConditionCommand
    {
        public abstract override bool Condition(long value);

        public override string Type()
        {
            return "CondElseDoNothing";
        }

        public override void Execution(Computer computer)
        {
            long value = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[1], computer));
            if (Condition(value))
            {
                Lib.Computer.Commands.MOV.Mov(args[2], args[0], computer);
            }
        }
    }
}
