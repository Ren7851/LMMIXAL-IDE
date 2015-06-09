using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Exceptions;

namespace Lib.Computer.Commands.GOTO
{
    public class GOTO:Jump
    {
        public GOTO(string labelName) 
        {
            args[0] = labelName;
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "GOTO [label]label";
            }
        }

        public override string Description
        {
            get
            {
                return "goto label";
            }
        }

        public override bool Condition(Computer computer)
        {
            return true;
        }

        public override string Type()
        {
            return "GOTO";
        }
    }
}
