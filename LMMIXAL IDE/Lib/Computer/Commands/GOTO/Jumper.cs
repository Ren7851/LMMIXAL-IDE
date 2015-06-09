using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.GOTO
{
    public class JUMP:Command
    {
        public JUMP(){
    
        }

        public JUMP(string hex)
        {
            args[0] = hex;
            hexArgs.Add(0);
            arity = 1;
        }


        public override string Type()
        {
            return "JUMP";
        }

        public override string Description
        {
            get
            {
                return "goto this+revalive_address";
            }
        }

        public override string Syntax
        {
            get
            {
                return "JUMP [hex]revalive_address";
            }
        }
        
        public override void Execution(Computer computer)
        {
            int jump = Utils.Utils.HexToInt(args[0]);
            computer.currentCommand = computer.currentCommand + jump;
        }
    }
}
