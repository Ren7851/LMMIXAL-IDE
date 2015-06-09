using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class PerfomanceExplorer
    {
        private void Normalise()
        {
           double max = lines.Max<double>();
           for(int i = 0; i<lines.Count; i++)
           {
               lines[i]/=max;
           }
        }

        public List<double> GetLines() 
        {
            Normalise();
            return lines;
        }

        List<double> lines;
        public PerfomanceExplorer(int numberOfCommands) 
        {
            lines = new List<double>();
            for (int i = 0; i < numberOfCommands; i++ )
            {
                lines.Add(0);
            }
        }

        public void Add(int line) 
        {
            lines[line]++;
        }
    }
}
