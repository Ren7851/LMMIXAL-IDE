using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.GOTO
{
    public class GOTOPOS : Jump
    {
        public GOTOPOS(string labelName, string address)
        {
            args[0] = labelName;
            args[1] = address;
            arity = 2;
            octoArgs.Add(1);
        }

        public override string Syntax
        {
            get
            {
                return "GOTOPOS [label]label [double | long] value";
            }
        }

        public override string Description
        {
            get
            {
                return "if(value>0) {goto label}";
            }
        }

        public override string Type()
        {
            return "GOTOPOS";
        }

        public override bool Condition(Computer computer)
        {
            return Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[1], computer)) > 0;
        }
    }
}
