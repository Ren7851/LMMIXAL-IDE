using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class IS : Command
    {
        public IS(string address, string name)
        {
            args[0] = name;
            args[1] = address;
            arity = 2;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "IS [octo]address [string]var_name";
            }
        }

        public override string Description
        {
            get
            {
                return "*var_name = &&address";
            }
        }

        public override string Type()
        {
            return "IS";
        }

        public override void Execution(Computer computer)
        {
        }
    }
}
