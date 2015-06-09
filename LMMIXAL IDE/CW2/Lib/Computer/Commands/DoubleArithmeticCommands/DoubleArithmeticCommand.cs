using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Computer.Commands
{
    public abstract class DoubleArithmeticCommand:Command
    {
        public DoubleArithmeticCommand(){}

        public DoubleArithmeticCommand(string operand1, string operand2) 
        {
            args[0] = operand1;
            args[1] = operand2;
            arity = 2;
        }

        public override string Type()
        {
            return "double arithmetic command";
        }

        public abstract double operation(double operand1, double operand2);

        public override void Execution(Computer computer)
        {
            double operand1 = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[0], computer));
            double operand2 = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[1], computer));
            double res = operation(operand1, operand2);
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.DoubleToOcto(res));
        }
    }
}
