using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class RANDOML:Command
    {
        public RANDOML(string address, string from, string to)
        {
            args[0] = address;
            args[1] = from;
            args[2] = to;
            arity = 3;
        }

        public override string Syntax
        {
            get
            {
                return "RANDOML [long]address [long]from [dec]to";
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
            return "RANDOML";
        }

        public override void Execution(Computer computer)
        {
            long from = Utils.Utils.HexToInt(args[1]);
            long to = Utils.Utils.HexToInt(args[2]);
            long randomValue = computer.random.Next((int)from, (int)(to+1));
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.LongToOcto(randomValue));
        }
    }
}
