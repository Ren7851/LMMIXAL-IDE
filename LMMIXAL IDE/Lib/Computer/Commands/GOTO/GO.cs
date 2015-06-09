using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.GOTO
{
    public class GO:Command
    {
        public GO(){
    
        }

        public GO(string reg)
        {
            args[0] = reg;
            octoArgs.Add(0);
            arity = 1;
        }


        public override string Type()
        {
            return "GO";
        }

        public override string Description
        {
            get
            {
                return "goto address";
            }
        }

        public override string Syntax
        {
            get
            {
                return "JUMP [octo]address";
            }
        }
        
        public override void Execution(Computer computer)
        {
            long newAddress = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[0], computer));
            computer.currentCommand = (int)(newAddress-1);
        }
    }
}
