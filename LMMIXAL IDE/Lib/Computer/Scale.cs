using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer
{
    public class Scale
    {
        public static double logBase = 1.0026723535;
        public static double PositionByValue(double value) 
        {
            return Math.Log(value, logBase);
        }

        public static double ValueByPosition(double position)
        {
            return Math.Pow(logBase, position);
        }
    }
}
