using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Computer.Commands;

namespace Lib.Computer
{
    public class Program
    {
        public List<Command> program;
        public List<KeyValuePair<string, string>> vars;
        public List<KeyValuePair<string, int>> errors;

        public Program() 
        {
            program = new List<Command>();
        }

        public Program(List<Command> list)
        {
            program = list;
        }

        public void SetVars()
        {
            vars = new List<KeyValuePair<string, string>>();

            for (int i = 0; i < program.Count; i++ )
            {
                if(program[i].Type() == new IS("","").Type())
                {
                    vars.Add(new KeyValuePair<string, string>(program[i].args[0], program[i].args[1]));
                }
            }
        }

    }
}
