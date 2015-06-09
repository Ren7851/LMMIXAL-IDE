using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer
{
    public class Memory
    {
        public const int MEMORY_SIZE = 256;
        public const int REGISTERS_NUMBER = 8;
        private OctoByte[] array;
        private OctoByte[] registers;

        public Memory()
        {
            array = new OctoByte[MEMORY_SIZE];
            registers = new OctoByte[REGISTERS_NUMBER];

            for (int i = 0; i < MEMORY_SIZE; i++)
            {
                this[i] = new OctoByte();
            }

            for (int i = 0; i < REGISTERS_NUMBER; i++)
            {
                registers[i] = new OctoByte();
            }
        }

        public OctoByte this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                if (i >= 0 && i < MEMORY_SIZE)
                {
                    array[i] = value;
                }
                else
                {
                    throw new ArgumentException("Index is " + i + ", and it is not in [0 - " + (MEMORY_SIZE - 1) + "]");
                }
            }
        }

        public OctoByte GetRegister(int number)
        {
            return registers[number];
        }

        public void SetRegister(int number, OctoByte octo)
        {
            registers[number] = octo;
        }
    }
}
