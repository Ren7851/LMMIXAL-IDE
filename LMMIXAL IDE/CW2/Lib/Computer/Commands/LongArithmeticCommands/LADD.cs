using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.LongArithmeticCommands
{
    public class LADD : LongArithmeticCommand
    {
        public LADD(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            arity = 2;
            octoArgs.Add(0);
            octoArgs.Add(1);
        }

        public override string Syntax
        {
            get
            {
                return "LADD [long]arg1 [long]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "arg1 += arg2";
            }
        }

        public override long operation(long operand1, long operand2)
        {
            return operand1 + operand2;
        }

        public override string Type()
        {
            return "LADD";
        }
    }
}
