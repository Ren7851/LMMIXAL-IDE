using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationMod:Operation
    {
        public OperationMod() 
        {
            arity = 2;
            symbol = "mod";
            priority = 1;
        }

        public override Operation Clone()
        {
            return new OperationMod();
        }

        public override double Calculate(params double[] args)
        {
            return  args[0] % args[1];
        }
    }
}
