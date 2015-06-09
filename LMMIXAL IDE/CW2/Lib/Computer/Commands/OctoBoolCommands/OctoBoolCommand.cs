using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public abstract class OctoBoolCommand : Command
    {
        public OctoBoolCommand() { }

        public OctoBoolCommand(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            arity = 2;
        }

        public override string Type()
        {
            return "boolean command";
        }

        public abstract bool operation(bool operand1, bool operand2);

        public override void Execution(Computer computer)
        {
            OctoByte operand1 = Utils.Utils.ParseAddress(args[0], computer);
            OctoByte operand2 = Utils.Utils.ParseAddress(args[1], computer);

            OctoByte res = new OctoByte();

            for (int i = 0; i < OctoByte.OCTO_SIZE; i++ )
            {
                for (int j = 0; j < Lib.Computer.Byte.BYTE_SIZE; j++ )
                {
                    res[i][j] = operation(operand1[i][j], operand2[i][j]);
                }
            }

            Utils.Utils.PutInAddress(args[0], computer, res);
        }
    }
}
