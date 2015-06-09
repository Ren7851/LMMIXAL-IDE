using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    public class LeftBracket:Element
    {
        public LeftBracket() 
        { 
        }

        public override string ToString()
        {
            return "(";
        }
    }
}
