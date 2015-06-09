using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands.GOTO
{
    public class GOTOZERO : Jump
    {
        public override string Syntax
        {
            get
            {
                return "GOTOZERO [label]label [double | long] value";
            }
        }

        public override string Description
        {
            get
            {
                return "if(value==0) {goto label}";
            }
        }


        public GOTOZERO(string labelName, string address)
        {
            args[0] = labelName;
            args[1] = address;
            arity = 2;
            octoArgs.Add(1);
        }

        public override string Type()
        {
            return "GOTOZERO";
        }

        public override bool Condition(Computer computer)
        {
            return Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[1], computer)) == 0;
        }
    }
}
