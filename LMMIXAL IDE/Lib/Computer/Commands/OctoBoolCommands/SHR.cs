using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.OctoBoolCommands
{
    public class SHR : Command
    {
        public SHR(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            octoArgs.Add(0);
            arity = 2;
        }

        public override string Syntax
        {
            get
            {
                return "SHR [octo]arg [dec]shl";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = arg >> shl";
            }
        }

        public override void Execution(Computer computer)
        {
            int ops = int.Parse(args[1]);
            OctoByte operand1 = Utils.Utils.ParseAddress(args[0], computer);

            bool[] bits = operand1.GetBits();

            bool[] newBits = new bool[OctoByte.OCTO_SIZE * Lib.Computer.Byte.BYTE_SIZE];

            for (int i = 0; i < bits.Length - ops; i++)
            {
                newBits[i + ops] = bits[i];
            }

            Utils.Utils.PutInAddress(args[0], computer, new OctoByte(newBits));
        }

        public override string Type()
        {
            return "SHR";
        }
    }
}
