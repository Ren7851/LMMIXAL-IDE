using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class OUTL : Command
    {
        public OUTL(string address)
        {
            args[0] = address;
            arity = 1;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "OUTL [long]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "write((long)arg)";
            }
        }


        public override string Type()
        {
            return "OUTL";
        }

        public override void Execution(Computer computer)
        {
            computer.console.Text += Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[0], computer));
        }
    }
}
