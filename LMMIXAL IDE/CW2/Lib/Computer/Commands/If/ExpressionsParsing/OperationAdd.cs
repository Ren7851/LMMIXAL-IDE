using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationAdd:Operation
    {
        public OperationAdd() 
        {
            arity = 2;
            symbol = "+";
            priority = 1;
        }

        public override Operation Clone()
        {
            return new OperationAdd();
        }

        public override double Calculate(params double[] args)
        {
            double res = 0;
            for (int i = 0; i < args.Length; i++ )
            {
                res += args[i];
            }
            return res;
        }
    }
}
