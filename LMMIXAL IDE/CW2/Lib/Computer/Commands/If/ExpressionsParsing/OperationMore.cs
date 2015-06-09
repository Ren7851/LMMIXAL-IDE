using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationMore : Operation
    {
        public OperationMore() 
        {
            arity = 2;
            symbol = "greater";
            priority = 0;
        }


        public override double Calculate(params double[] args)
        {
            if (args[0] > args[1])
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
            return new OperationMore();
        }
    }
}
