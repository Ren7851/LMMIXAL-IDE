using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class IN:Command
    {
        public IN(string what, string to) 
        {
            try
            {
                args[0] = new string('0', 16 - to.Length) + to;
            }
            catch(Exception e)
            {
                args[0] = to;
            }

            args[1] = what;
            arity = 2;
            octoArgs.Add(1);

            

            hexArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "IN [octo]address [hex]value";
            }
        }

        public override string Description
        {
            get
            {
                return "address = value";
            }
        }


        public override string Type()
        {
            return "IN";
        }

        public override void Execution(Computer computer)
        {
            Utils.Utils.PutInAddress(args[1], computer, args[0]);
        }
    }
}
