using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public class IND:ConsoleInputCommand
    {
        public IND(string address) {
            args[0] = address;
            arity = 1;
            octoArgs.Add(0);
        }

        public override string Type()
        {
            return "IND";
        }

        public override string Syntax
        {
            get
            {
                return "IND [double]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = read()";
            }
        }

        public override OctoByte Excecute(string input) {
            return Utils.Utils.DoubleToOcto(Double.Parse(input));
        }
    }
}
