using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    public abstract class Operation:Element
    {
        public string symbol;
        public int priority;

        public string GetSymbol() 
        {
            return symbol;
        }

        public abstract double Calculate(params double[] args);

        public abstract Operation Clone();

        public override string ToString()
        {
            return symbol;
        }
    }
}
