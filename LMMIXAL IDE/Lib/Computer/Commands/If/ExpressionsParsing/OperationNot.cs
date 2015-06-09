using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationNot:Operation
    {
        public OperationNot() 
        {
            arity = 1;
            symbol = "not";
            priority = 0;
        }


        public override double Calculate(params double[] args)
        {
            if (Value.Equal(args[0], 0))
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }

        public override Operation Clone()
        {
            return new OperationNot();
        }
    }
}
