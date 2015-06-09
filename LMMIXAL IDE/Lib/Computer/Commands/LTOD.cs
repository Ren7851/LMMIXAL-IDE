using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class LTOD:Command
    {
        public LTOD(string address) 
        {
            args[0] = address;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "DTOL [long]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = (double)arg";
            }
        }

        public override void Execution(Computer computer)
        {
            long value = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[0], computer));
            double doubleValue = (double)value;
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.DoubleToOcto(doubleValue));
        }

        public override string Type()
        {
            return "LTOD";
        }
    }
}
