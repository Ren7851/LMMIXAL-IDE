using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationDiv : Operation
    {
        public OperationDiv() 
        {
            arity = 2;
            symbol = "/";
            priority = 2;
        }

        public override double Calculate(params double[] args)
        {
            double res = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                res /= args[i];
            }
            return res;
        }

        public override Operation Clone()
        {
            return new OperationDiv();
        }
    }
}
