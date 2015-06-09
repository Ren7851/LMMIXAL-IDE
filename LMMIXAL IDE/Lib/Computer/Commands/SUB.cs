using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class SUB:Command
    {
        public SUB(string name) 
        {
            args[0] = name;
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "SUB [proc_name]f";
            }
        }

        public override string Description
        {
            get
            {
                return "void f{";
            }
        }

        public override string Type()
        {
            return "SUB";
        }

        public override void Execution(Computer computer)
        {
        }
    }
}
