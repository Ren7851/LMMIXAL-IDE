using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ConditionActions
{
    public class CSNP : CondElseDoNothing
    {
        public CSNP(string to, string address, string from)
        {
            args[0] = to;
            args[1] = address;
            args[2] = from;
            arity = 3;
        }

        public override string Syntax
        {
            get
            {
                return "CSNP [long]to [long]address [long]from";
            }
        }

        public override string Description
        {
            get
            {
                return "if(address<=0){to = from}";
            }
        }

        public override bool Condition(long value)
        {
            return value <= 0;
        }

        public override string Type()
        {
            return "CSNP";
        }
    }
}
