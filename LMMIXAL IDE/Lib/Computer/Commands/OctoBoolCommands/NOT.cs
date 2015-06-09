using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class NOT : Command
    {
        public NOT(string operand1)
        {
            args[0] = operand1;
            octoArgs.Add(0);
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "NOT [bool]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = !arg";
            }
        }

        public override string Type()
        {
            return "NOT";
        }
        public override void Execution(Computer computer)
        {
            OctoByte operand = Utils.Utils.ParseAddress(args[0], computer);

            OctoByte res = new OctoByte();

            for (int i = 0; i < OctoByte.OCTO_SIZE; i++)
            {
                for (int j = 0; j < Lib.Computer.Byte.BYTE_SIZE; j++)
                {
                    res[i][j] = ! operand[i][j];
                }
            }

            Utils.Utils.PutInAddress(args[0], computer, res);
        }
        
    }
}
