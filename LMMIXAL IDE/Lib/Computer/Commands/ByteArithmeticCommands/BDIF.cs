﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ByteArithmeticCommands
{
    public class BDIF:ByteArithmeticCommand
    {
        public BDIF(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            arity = 2;
            byteArgs.Add(0);
            byteArgs.Add(1);
        }

        public override string Syntax
        {
            get
            {
                return "BDIF [byte]arg1 [byte]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "arg1 = max(0, arg1 - arg2)";
            }
        }

        public override sbyte operation(sbyte operand1, sbyte operand2)
        {
            return (sbyte)Math.Max(0, operand1 - operand2);
        }

        public override string Type()
        {
            return "BDIF";
        }
    }
}
