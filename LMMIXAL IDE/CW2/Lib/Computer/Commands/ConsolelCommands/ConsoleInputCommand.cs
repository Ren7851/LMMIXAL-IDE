using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.ConsolelCommands
{
    public abstract class ConsoleInputCommand:Command
    {
        public ConsoleInputCommand(){}

        public ConsoleInputCommand(string address) 
        {
            arity = 1;
            args[0] = address;
        }

        public override string Type()
        {
            return "console input command";
        }

        public void SetValue(string input) 
        {
            args[1] = input;
        }

        public abstract OctoByte Excecute(string input);

        public override void Execution(Computer computer)
        {
            Utils.Utils.PutInAddress(args[0], computer, Excecute(args[1]));
        }
    }
}
