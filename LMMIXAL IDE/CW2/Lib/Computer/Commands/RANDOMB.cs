using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class RANDOMB : Command
    {
        public RANDOMB(string address, string from, string to)
        {
            args[0] = address;
            args[1] = from;
            args[2] = to;
            arity = 3;
            byteArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "RANDOMB [byte]address [dec]from [dec]to";
            }
        }

        public override string Description
        {
            get
            {
                return "address = rand(from, to)";
            }
        }

        public override string Type()
        {
            return "RANDOMB";
        }

        public override void Execution(Computer computer)
        {
            sbyte from = (sbyte)Utils.Utils.HexToInt(args[1]);
            sbyte to = (sbyte)Utils.Utils.HexToInt(args[2]);
            sbyte randomValue = (sbyte)computer.random.Next(from, to+1);
            Utils.Utils.PutInByteAddress(args[0], computer, new Byte(randomValue));
        }
    }
}
