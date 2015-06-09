using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Cache
    {
        private List<KeyValuePair<double, double>> table;
       
        public void Add(double key, double value)
        {
           table.Add(new KeyValuePair<double, double>(key, value));
        }

        public double Find(double key)
        {
            for(int i = 0; i<table.Count; i++)
            {
               if(table[i].Key == key)
               {
                   return table[i].Value;
               }
            }
            return 0.0/0.0;
        }
    }
}
