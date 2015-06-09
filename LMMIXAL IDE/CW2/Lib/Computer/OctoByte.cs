using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Computer
{
    public class OctoByte
    {
        public const int OCTO_SIZE = 8;
        private Byte[] array = new Byte[OCTO_SIZE];

        public OctoByte()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Byte();
            }
        }

        public OctoByte(string hexStr) 
        {
            hexStr = Utils.Utils.DeleteSpaces(hexStr);
            if (hexStr.Length != OCTO_SIZE*2)
            {
                throw new ArgumentException("Input string of octo must have " + (OCTO_SIZE * 2) + " symbols, not " + hexStr.Length);
            }

            for (int i = 0; i < OCTO_SIZE; i++ )
            {
                string bt = hexStr.Substring(i * 2, 2);
                this[i] = new Byte(bt);
            }
        }

        public OctoByte(bool[] ar) {
            for (int i = 0; i < array.Length; i++)
            {
                this[i] = new Byte();
            }

            for (int i = 0; i < OctoByte.OCTO_SIZE; i++)
            {
                for (int j = 0; j < Lib.Computer.Byte.BYTE_SIZE; j++)
                {
                    int index = i * Lib.Computer.Byte.BYTE_SIZE + j;
                    this[i][j] = ar[index];
                }
            }
        }

        public OctoByte Copy()
        {
            OctoByte res = new OctoByte();
            for (int i = 0; i < OCTO_SIZE; i++ )
            {
                res[i] = this[i].Copy();
            }
            return res;
        }

        public bool this[int i, int j]
        {
            get
            {
                return array[i][j];
            }
            set
            {
                array[i][j] = value;
            }
        }

        public string HexString() 
        {
            string res = "";

            for (int i = 0; i < OCTO_SIZE; i++ )
            {
                res += this[i].HexString+"";
            }

            return res;
        }

        public Byte this[int i]
        {
            get
            {
                if (i < 0 || i >= OCTO_SIZE)
                {
                    throw new ArgumentException("Attemp to access "+i+"-th element of octo");
                }
                return array[i];
            }
            set
            {
                if (i >= 0 && i < OCTO_SIZE)
                {
                    array[i] = value;
                }
                else
                {
                    throw new ArgumentException("Index is " + i + ", and it is not in [0 - " + (OCTO_SIZE - 1) + "]");
                } 
            }
        }


        public bool[] GetBits() 
        {
            bool[] res = new bool[OCTO_SIZE*Byte.BYTE_SIZE];
            int count = 0;
            for (int i = 0; i < OCTO_SIZE; i++ )
            {
                for (int j = 0; j < Byte.BYTE_SIZE; j++ )
                {
                    res[count] = this[i][j];
                    count++;
                }
            }
            return res;
        }

        public override string ToString()
        {
            string res = "";

            bool[] bits = GetBits();
            for (int i = 0; i < bits.Length; i++ )
            {
                res += Utils.Utils.BoolToString(bits[i]);
            }

            return res;
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType().Equals(this.GetType()))
            {
                OctoByte octo = (OctoByte)obj;
                bool[] bits1 = this.GetBits();
                bool[] bits2 = octo.GetBits();

                for (int i = 0; i < bits1.Length; i++ )
                {
                    if(bits1[i]!=bits2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else{
              return false;
            }
        }
    }
}
