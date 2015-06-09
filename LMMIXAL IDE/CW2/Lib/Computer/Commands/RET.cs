using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class RET : Command
    {
        public override string Syntax
        {
            get
            {
                return "RET";
            }
        }

        public override string Description
        {
            get
            {
                return "return}";
            }
        }

        public RET()
        {
            arity = 0;
        }

        public override string Type()
        {
            return "RET";
        }

        public override void Execution(Computer computer)
        {
            string address = computer.Pop();
            int temp = Utils.Utils.HexToInt(address);
            computer.currentCommand = temp;
        }
    }
}
