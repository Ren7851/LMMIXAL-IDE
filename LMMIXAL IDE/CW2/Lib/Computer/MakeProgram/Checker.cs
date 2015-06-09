using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.MakeProgram
{
    class Checker
    {
        public static List<string> Check(string text) 
        {
           List<string> errors = new List<string>();

           if(text.IndexOf("HALT")==-1)
           {
               errors.Add("Программа не содержит команды HALT");
           }

           return errors;
        }
    }
}
