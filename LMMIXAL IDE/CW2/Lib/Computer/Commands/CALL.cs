using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class CALL : Command
    {
        public CALL(string func, string[] args)
        {
            this.args[0] = func;
            
            for (int i = 1; i < args.Length + 1; i++)
            {
                this.args[i] = args[i - 1];
            }

            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "CALL [proc_name]f";
            }
        }

        public override string Description
        {
            get
            {
                return "f()";
            }
        }

        public override string Type()
        {
            return "CALL";
        }

        public override void Execution(Computer computer)
        {
            string address = Convert.ToString(number, 16);
            address = new string('0', 16 - address.Length) + address;
            computer.Push(address);

            for (int i = 1; i < args.Length; i++)
            {
                if ((args[i] != null) && args[i].Length != 0)
                {
                    computer.Push(Utils.Utils.ParseAddress(args[i], computer).HexString());
                }
            }

            for (int i = 0; i < computer.program.program.Count; i++)
            {
                Command command = computer.program.program[i];
                if (command.Type() == new SUB("").Type())
                {
                    if (command.args[0] == this.args[0])
                    {
                        computer.currentCommand = i - 1;
                        break;
                    }
                }
            }
        }
    }
}
