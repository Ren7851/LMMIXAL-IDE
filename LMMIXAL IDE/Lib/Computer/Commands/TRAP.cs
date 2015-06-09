using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class TRAP:Command
    {
        public override string Syntax
        {
            get
            {
                return "TRAP";
            }
        }

        public override string Description
        {
            get
            {
                return "Точка останова";
            }
        }

        public TRAP()
        {
            arity = 0;
        }

        public override string Type()
        {
            return "TRAP";
        }

        public override void Execution(Computer computer)
        {
            computer.VisualizeCommand();
            computer.VisualizeStack();
            computer.view.Refresh();
            computer.console.Refresh();
        }
    }
}
