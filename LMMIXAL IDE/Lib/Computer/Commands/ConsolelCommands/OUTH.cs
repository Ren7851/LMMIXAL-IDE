using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class OUTH : Command
    {
        public OUTH(string address)
        {
            args[0] = address;
            arity = 1;
            octoArgs.Add(0);
        }

        public override string Type()
        {
            return "OUTH";
        }

        public override string Syntax
        {
            get
            {
                return "OUTH [octo]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "write(arg)";
            }
        }

        public override void Execution(Computer computer)
        {
            computer.console.Text +=Utils.Utils.ParseAddress(args[0], computer).HexString();
        }
    }
}
