using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class CEIL:Command
    {
        public CEIL(string address) 
        {
            args[0] = address;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "CEIL [double]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = ceil(arg)";
            }
        }

        public override void Execution(Computer computer)
        {
            double value = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[0], computer));
            double newValue = Math.Ceiling(value);
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.DoubleToOcto(newValue));
        }

        public override string Type()
        {
            return "CEIL";
        }
    }
}
