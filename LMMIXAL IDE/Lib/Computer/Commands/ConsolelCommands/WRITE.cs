using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class WRITE:Command
    {
        public WRITE(string message) 
        {
            args[0] = message;
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "WRITE [string]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "write(string)";
            }
        }

        public override string Type()
        {
            return "WRITE";
        }

        public override void Execution(Computer computer)
        {
            args[0] = args[0].Replace('@', ' ');
            computer.console.Text += args[0];
        }
    }
}
