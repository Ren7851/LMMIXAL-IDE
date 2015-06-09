using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class POP : Command
    {
        public POP()
        {
            arity = 0;
        }

        public override string Syntax
        {
            get
            {
                return "POP";
            }
        }

        public override string Description
        {
            get
            {
                return "stack.pop()";
            }
        }

        public override string Type()
        {
            return "POP";
        }

        public override void Execution(Computer computer)
        {
            computer.Pop();
        }
    }
}
