using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lib.Computer.Commands.ByteArithmeticCommands
{
    public abstract class ByteArithmeticCommand : Command
    {
        public ByteArithmeticCommand() { }

        public ByteArithmeticCommand(string operand1, string operand2)
        {
            args[0] = operand1;
            args[1] = operand2;
            arity = 2;
        }

        public override string Type()
        {
            return "byte arithmetic command";
        }

        public abstract sbyte operation(sbyte operand1, sbyte operand2);

        public override void Execution(Computer computer)
        {
            Lib.Computer.Byte byte1 = Utils.Utils.ParseByteAddress(args[0], computer);
            Lib.Computer.Byte byte2 = Utils.Utils.ParseByteAddress(args[1], computer);
            sbyte operand1 = (sbyte)byte1.Value(Format.TwosComplement);
            sbyte operand2 = (sbyte)byte2.Value(Format.TwosComplement);
            //MessageBox.Show(operand1 + " " + operand2);
            sbyte res = operation(operand1, operand2);
            Lib.Computer.Byte byteRes = new Lib.Computer.Byte(res);
            Utils.Utils.PutInByteAddress(args[0], computer, byteRes);
        }
    }
}
