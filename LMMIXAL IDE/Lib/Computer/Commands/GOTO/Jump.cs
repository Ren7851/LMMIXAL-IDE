using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Exceptions;

namespace Lib.Computer.Commands.GOTO
{
    public abstract class Jump : Command
    {
        public Jump(){
    
        }

        public Jump(string labelName)
        {
            args[0] = labelName;
            arity = 1;
        }


        public override string Type()
        {
            return "Jump";
        }
        
        public abstract bool Condition(Computer computer);

        public override void Execution(Computer computer)
        {
            if (Condition(computer))
            {
                int begin = computer.currentCommand;

                do
                {
                    begin--;
                    if(begin == 0)
                    {
                        break;
                    }
                }
                while (computer.program.program[begin].Type() != new SUB("").Type());

                for (int i = begin; i < computer.program.program.Count; i++)
                {
                    Command command = computer.program.program[i];
                    if (command.Type() == new LABEL("").Type())
                    {
                        if (command.Args[0] == this.args[0])
                        {
                            computer.currentCommand = i - 1;
                            return;
                        }
                    }
                }
                throw new NoSuchLabelException();
            }
        }
    }
}
