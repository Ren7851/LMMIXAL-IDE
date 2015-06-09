using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class ROUND:Command
    {
        public ROUND(string address, string digits) 
        {
            args[0] = address;
            args[1] = digits;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "ROUND [double]arg [dec]precision";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = rnd(arg, precision)";
            }
        }

        public override void Execution(Computer computer)
        {
            double value = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[0], computer));
            double newValue = Math.Round(value, int.Parse(args[1]));
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.DoubleToOcto(newValue));
        }

        public override string Type()
        {
            return "ROUND";
        }
    }
}
