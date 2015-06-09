using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class DLOG : DoubleArithmeticCommand
    {
        public DLOG(string operand1, string operand2)
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
                return "DLOG [double]arg1 [double]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "arg1 = log по arg1 от arg2";
            }
        }

        public override double operation(double operand1, double operand2)
        {
            return Math.Log(operand2, operand1);
        }

        public override string Type()
        {
            return "DLOG";
        }
    }
}
