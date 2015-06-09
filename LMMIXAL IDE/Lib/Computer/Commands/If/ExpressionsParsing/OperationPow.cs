using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationPow : Operation
    {
        public OperationPow()
        {
            arity = 2;
            symbol = "^";
            priority = 4;
        }

        public override Operation Clone()
        {
            return new OperationPow();
        }

        public override double Calculate(params double[] args)
        {
            return Math.Pow(args[0], args[1]);
        }
    }
}
