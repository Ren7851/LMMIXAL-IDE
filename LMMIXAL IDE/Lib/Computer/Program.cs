using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Computer.Commands;
using System.Windows.Forms;

namespace Lib.Computer
{
    public class Program
    {
        public class IntPair
        {
            public int begin;
            public int end;

            public IntPair(int begin, int end)
            {
                this.begin = begin;
                this.end = end;
            }
        }

        public List<Command> program;
        public List<KeyValuePair<string, string>> vars;
        public List<KeyValuePair<string, int>> errors;
        public List<IntPair> linesBeginEnd;

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
                    vars.Add(new KeyValuePair<string, string>(program[i].Args[0], program[i].Args[1]));
                }
            }
        }

        public void setLinesPairs(RichTextBox box) 
        {
            linesBeginEnd = new List<IntPair>();
            int summ = 0;
            for (int i = 0; i < box.Lines.Length; i++)
            {
                int begin = summ;
                int end = summ + box.Lines[i].Length;

                summ += box.Lines[i].Length;
                summ++;

                linesBeginEnd.Add(new IntPair(begin, end));
            }
        }

    }
}
