using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class EXPR:Command
    {
        public EXPR(string address, string expression) 
        {
            args[0] = address;
            args[1] = expression;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "EXPR [double]value <[expression]expression>";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = expression";
            }
        }

        public override void Execution(Computer computer)
        {
            Lib.Computer.Commands.If.ExpressionsParsing.Expression expression = IF.GetExpression(args[1]);
            double value = expression.Calculate(computer);
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.DoubleToOcto(value));
        }

        public override string Type()
        {
            return "EXPR";
        }
    }
}
