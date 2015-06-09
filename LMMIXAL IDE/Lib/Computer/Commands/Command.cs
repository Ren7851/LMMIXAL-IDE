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
        protected int arity;
        protected string[] args = new string[3];
        public abstract string Type();

        public List<int> octoArgs = new List<int>();
        public List<int> byteArgs = new List<int>();
        public List<int> hexArgs = new List<int>();
        public List<int> decArgs = new List<int>();

        public int Number
        {
            set
            {
                number = value;
            }
        }

        public int Arity
        {
            get
            {
                return arity;
            }
        }

        public string[] Args
        {
            get
            {
                return args;
            }
        }

        public List<int> OctoArgs
        {
           get
           {
               return octoArgs;
           }
        }


        public List<int> ByteArgs
        {
            get
            {
                return byteArgs;
            }
        }

        public List<int> HexArgs
        {
            get
            {
                return hexArgs;
            }
        }

        public List<int> DecArgs
        {
            get
            {
                return decArgs;
            }
        }

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
            computer.deselectAll();
            Execution(computer);
        }

        public abstract void Execution(Computer computer);
    }
}
