using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationAnd:Operation
    {
        public OperationAnd() 
        {
            arity = 2;
            symbol = "and";
            priority = 0;
        }

        public override Operation Clone()
        {
            return new OperationAnd();
        }

        public override double Calculate(params double[] args)
        {
            if (!(Value.Equal(args[0], 0)) && !(Value.Equal(args[1], 0)))
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }
    }
}
