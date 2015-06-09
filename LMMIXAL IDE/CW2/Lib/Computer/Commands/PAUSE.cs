using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lib.Computer.Commands
{
    public class PAUSE : Command
    {
        public PAUSE(string time)
        {
            args[0] = time;
            arity = 1;
        }

        public override string Type()
        {
            return "PAUSE";
        }

        public override string Syntax
        {
            get
            {
                return "PAUSE [dec]milliseconds";
            }
        }

        public override string Description
        {
            get
            {
                return "pause(milliseconds)";
            }
        }

        public override void Execution(Computer computer)
        {
            computer.VisualizeCommand();
            computer.VisualizeStack();
            computer.view.Refresh();
            computer.console.Refresh();
            Console.Beep(600, int.Parse(args[0]));
            System.Threading.Thread.Sleep(int.Parse(args[0]));
            computer.box.SelectionStart = 0;
            computer.box.SelectionLength = computer.box.Text.Length;
            computer.box.SelectionBackColor = Color.White;
            computer.box.Refresh();
            computer.VisualizeCommand();
            computer.VisualizeStack();
            computer.view.Refresh();
            computer.console.Refresh();
        }
    }
}
