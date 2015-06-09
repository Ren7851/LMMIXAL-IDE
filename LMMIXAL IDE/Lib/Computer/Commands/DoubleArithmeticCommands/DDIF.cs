using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.DoubleArithmeticCommands
{
    public class DDIF:DoubleArithmeticCommand
    {
        public DDIF(string operand1, string operand2)
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
                return "DDIF [double]arg1 [double]arg2";
            }
        }

        public override string Description
        {
            get
            {
                return "arg1 = max(0, arg1 - arg2)";
            }
        }

        public override double operation(double operand1, double operand2)
        {
            return Math.Max(0, operand1 - operand2);
        }

        public override string Type()
        {
            return "DDIF";
        }
    }
}
