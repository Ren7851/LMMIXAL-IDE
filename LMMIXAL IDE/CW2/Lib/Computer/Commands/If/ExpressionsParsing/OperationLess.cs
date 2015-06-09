using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class OperationLess:Operation
    {
        public OperationLess() 
        {
            arity = 2;
            symbol = "less";
            priority = 0;
        }


        public override double Calculate(params double[] args)
        {
            if (args[0] < args[1])
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
            return new OperationLess();
        }
    }
}
