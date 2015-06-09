using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class ENDIF : Command
    {
        public ENDIF()
        {
            arity = 0;
        }

        public override string Syntax
        {
            get
            {
                return "ENDIF";
            }
        }

        public override string Description
        {
            get
            {
                return "}";
            }
        }

        public override string Type()
        {
            return "ENDIF";
        }

        public override void Execution(Computer computer)
        {
        }
    }
}
