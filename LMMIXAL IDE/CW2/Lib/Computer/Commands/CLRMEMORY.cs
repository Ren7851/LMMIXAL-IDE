using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer.Commands
{
    public class CLRMEMORY:Command
    {
        public CLRMEMORY() 
        {
            arity = 0;
        }

        public override string Syntax
        {
            get
            {
                return "CLRMEMORY";
            }
        }

        public override string Description
        {
            get
            {
                return "Очистка памяти";
            }
        }

        public override string Type()
        {
            return "CLRMEMORY";
        }

        public override void Execution(Computer computer)
        {
            for (int i = 0; i < Memory.MEMORY_SIZE; i++)
            {
                computer.memory[i] = new OctoByte();
            }

            for (int i = 0; i < Memory.REGISTERS_NUMBER; i++)
            {
                computer.memory.SetRegister(i, new OctoByte());
            }
        }

    }
}
