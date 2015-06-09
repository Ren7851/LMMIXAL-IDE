using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationOr:Operation
    {
        public OperationOr() 
        {
            arity = 2;
            symbol = "or";
            priority = 0;
        }

        public override Operation Clone()
        {
            return new OperationOr();
        }

        public override double Calculate(params double[] args)
        {
            if (!(Value.Equal(args[0], 0)) || !(Value.Equal(args[1], 0)))
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
