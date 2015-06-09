using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.OctoBoolCommands
{
    public class SHL : Command
    {
        public SHL(string operand1, string operand2)
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
                return "SHL [octo]arg [dec]shl";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = arg << shl";
            }
        }

        public override void Execution(Computer computer)
        {
            int ops = int.Parse(args[1]);
            bool[] newBits = new bool[OctoByte.OCTO_SIZE * Lib.Computer.Byte.BYTE_SIZE];

            OctoByte operand1 = Utils.Utils.ParseAddress(args[0], computer);

            bool[] bits = operand1.GetBits();

            for (int i = 0; i < bits.Length - ops; i++)
            {
                newBits[i] = bits[i + ops];
            }

            bits = newBits;

            OctoByte res = new OctoByte(newBits);
            Utils.Utils.PutInAddress(args[0], computer, res);
        }

        public override string Type()
        {
            return "SHL";
        }
    }
}
