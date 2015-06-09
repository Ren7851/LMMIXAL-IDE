using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationMoreEqual : Operation
    {
        public OperationMoreEqual() 
        {
            arity = 2;
            symbol = "meq";
            priority = 0;
        }


        public override double Calculate(params double[] args)
        {
            if (args[0] > args[1] ||  Value.Equal(args[0], args[1]))
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
            return new OperationMoreEqual();
        }
    }
}
