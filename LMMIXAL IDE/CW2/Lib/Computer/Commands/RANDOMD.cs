using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class RANDOMD : Command
    {
        public RANDOMD(string address)
        {
            args[0] = address;
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "RANDOMD [double]address";
            }
        }

        public override string Description
        {
            get
            {
                return "address = random(0, 1)";
            }
        }

        public override string Type()
        {
            return "RANDOMD";
        }

        public override void Execution(Computer computer)
        {
            double randomValue = computer.random.NextDouble();
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.DoubleToOcto(randomValue));
        }
    }
}
