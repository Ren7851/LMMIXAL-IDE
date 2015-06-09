using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class DTOL:Command
    {
        public DTOL(string address) 
        {
            args[0] = address;
            octoArgs.Add(0);
        }

        public override string Syntax
        {
            get
            {
                return "DTOL [double]arg";
            }
        }

        public override string Description
        {
            get
            {
                return "arg = (long)arg";
            }
        }

        public override void Execution(Computer computer)
        {
            double value = Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(args[0], computer));
            long longValue = (long)value;
            Utils.Utils.PutInAddress(args[0], computer, Utils.Utils.LongToOcto(longValue));
        }

        public override string Type()
        {
            return "DTOL";
        }
    }
}
