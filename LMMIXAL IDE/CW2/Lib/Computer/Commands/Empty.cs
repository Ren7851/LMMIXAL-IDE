using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    class Empty : Command
    {
        public Empty() 
        {
            arity = 0;
        }


        public override string Type()
        {
            return "Empty";
        }

        public override void Execution(Computer computer)
        {
        }

        public override void Execute(Computer computer)
        {
        }
    }
}
