﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ConditionActions
{
    public class CSOD : CondElseDoNothing
    {
        public CSOD(string to, string address, string from)
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
                return "CSOD [long]to [long]address [long]from";
            }
        }

        public override string Description
        {
            get
            {
                return "if(address%2 == 1){to = from}";
            }
        }

        public override bool Condition(long value)
        {
            return value % 2 == 1;
        }

        public override string Type()
        {
            return "CSOD";
        }
    }
}
