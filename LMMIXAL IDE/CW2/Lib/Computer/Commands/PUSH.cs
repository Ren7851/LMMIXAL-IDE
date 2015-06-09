using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class PUSH : Command
    {
        public PUSH(string address)
        {
            args[0] = address;
            octoArgs.Add(0);
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "PUSH [octo]address";
            }
        }

        public override string Description
        {
            get
            {
                return "stack.push(address)";
            }
        }

        public override string Type()
        {
            return "PUSH";
        }

        public override void Execution(Computer computer)
        {
            computer.Push(Utils.Utils.ParseAddress(args[0], computer).HexString());
        }
    }
}
