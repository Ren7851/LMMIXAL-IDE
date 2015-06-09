using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class INL : ConsoleInputCommand
    {
        public INL(string address)
        {
            args[0] = address;
            arity = 1;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "INL [long]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = read()";
            }
        }

        public override string Type()
        {
            return "INL";
        }

        public override OctoByte Excecute(string input)
        {
            return Utils.Utils.LongToOcto(long.Parse(input));
        }
    }
}
