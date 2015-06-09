using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class HALT:Command
    {
        public HALT() 
        {
            arity = 0;
        }

        public override string Syntax
        {
            get
            {
                return "HALT";
            }
        }

        public override string Description
        {
            get
            {
                return "Конец программы";
            }
        }

        public override string Type()
        {
            return "HALT";
        }

        public override void Execution(Computer computer)
        {
        }
    }
}
