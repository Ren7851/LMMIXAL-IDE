using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class OUTD : Command
    {
        public OUTD(string address)
        {
            args[0] = address;
            arity = 1;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "OUTD [double]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "write((double)arg)";
            }
        }

        public override string Type()
        {
            return "OUTD";
        }

        public override void Execution(Computer computer)
        {
            computer.console.Text += Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[0], computer));
        }
    }
}
