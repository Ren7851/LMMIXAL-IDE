using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.GOTO
{
    public class LABEL:Command
    {
        public LABEL(string labelName) 
        {
            args[0] = labelName;
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "LABEL [string]label";
            }
        }

        public override string Description
        {
            get
            {
                return ":label";
            }
        }

        public override string Type()
        {
            return "LABEL";
        }

        public override void Execution(Computer computer)
        {
        }
    }
}
