using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lib.Computer.Commands
{
    public abstract class Command : IComparable
    {
        public int number;
        public int arity;
        public string[] args = new string[3];
        public abstract string Type();

        public List<int> octoArgs = new List<int>();
        public List<int> byteArgs = new List<int>();
        public List<int> hexArgs = new List<int>();
        public List<int> decArgs = new List<int>();

        public virtual string Syntax
        {
            get
            {
                return " shit ";
            }
        }

        public virtual string Description
        {
           get
           {
             return arity+" арная операция "+Type();
           }
        }

        public int CompareTo(object obj)
        {
            Command command = (Command)obj;
            return this.Type().CompareTo(command.Type());
        }

        public virtual void Execute(Computer computer) 
        {
            if(computer.fastMode == false)
            {
                if (computer.isBeeps)
                {
                    Console.Beep(600, computer.beepDuration);
                }
                else 
                {
                    System.Threading.Thread.Sleep(computer.beepDuration);
                }
            }
            //System.Threading.Thread.Sleep(200);
            Execution(computer);
        }

        public abstract void Execution(Computer computer);
    }
}
