using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.OctoBoolCommands
{
    public abstract class MatrixCommand:Command
    {
        public MatrixCommand(string res, string operand1, string operand2)
        {
            args[0] = res;
            args[1] = operand1;
            args[2] = operand2;
            arity = 3;
            octoArgs.Add(0);
            octoArgs.Add(1);
            octoArgs.Add(2);
        }

        public abstract bool TopOperation(bool a, bool b);
        public abstract bool BottomOperation(bool a, bool b);

        public override string Type()
        {
            return "matrix";
        }

        public override void Execution(Computer computer)
        {
            OctoByte operand1 = Utils.Utils.ParseAddress(args[1], computer);
            OctoByte operand2 = Utils.Utils.ParseAddress(args[2], computer);

            OctoByte res = new OctoByte();

            for (int i = 0; i < OctoByte.OCTO_SIZE; i++)
            {
                for (int j = 0; j < Lib.Computer.Byte.BYTE_SIZE; j++)
                {
                    bool summ = false;

                    for (int k = 0; k < Lib.Computer.Byte.BYTE_SIZE; k++)
                    {
                        summ = TopOperation(summ, BottomOperation(operand1[i][k], operand2[k][j]));
                    }

                    res[i][j] = summ;
                }
            }

            Utils.Utils.PutInAddress(args[0], computer, res);
        }
    }
}
