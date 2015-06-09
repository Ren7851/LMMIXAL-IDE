using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ConditionActions
{
    public abstract class ConditionCommand : Command
    {
        public override string Type()
        {
            return "ConditionCommand";
        }

        public abstract bool Condition(long value);

        public override void Execution(Computer computer)
        {
        }
    }
}
