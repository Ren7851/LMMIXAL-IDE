using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Utils;
using System.Windows.Forms;

namespace Lib.Computer
{
    /// <summary>
    /// Enum, которое реализует форматы представления чисел по стандарту IEEE. 
    /// </summary>
    public enum Format : byte
    {
        SignAndMagnitude = 1,
        TwosComplement = 2,
        OnesComplement = 3,
        Classic = 4
    }

    //Биты хранятся как Little Endian. Например, 00000001 = 1. Первый бит - знаковый
    public class Byte
    {
        public const int BYTE_SIZE = 8;
        private bool[] array;

        private void InitByString(string str)
        {
            array = new bool[BYTE_SIZE];
            if (str.Length != BYTE_SIZE)
            {
                throw new ArgumentException("Input string has invalid length = " + str.Length + " chars");
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '1' && str[i] != '0')
                {
                    throw new ArgumentException("Input string contains not only 1-s or 0-s");
                }
                array[i] = str[i] == '1';
            }
        }

        public Byte()
        {
            array = new bool[BYTE_SIZE];
        }

        public Byte(sbyte value)
        {
            string s = Convert.ToString(value, 2);

            if (s.Length > BYTE_SIZE)
            {
                s = s.Substring(BYTE_SIZE);
            }

            s = new string('0', BYTE_SIZE - s.Length) + s;
            InitByString(s);
        }

        public Byte(char[] str)
        {
            InitByString(new string(str));
        }

        public Byte(string str)
        {
            int value = Utils.Utils.HexToInt(str);
            string s = Convert.ToString(value, 2);
            s = new string('0', BYTE_SIZE - s.Length) + s;
            InitByString(s);
        }

        public Byte(bool[] array)
        {
            if (array.Length != BYTE_SIZE)
            {
                throw new ArgumentException("Array size is not equal to byte size");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    this[i] = array[i];
                }
            }
        }

        public bool this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                if (i >= 0 && i < BYTE_SIZE)
                {
                    array[i] = value;
                }
                else
                {
                    throw new ArgumentException("Index is " + i + ", and it is not in [0 - " + (BYTE_SIZE - 1) + "]");
                }
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (this[i])
                {
                    res += "1";
                }
                else
                {
                    res += "0";
                }
            }
            return res;
        }

        public int Value(Format format)
        {
            if (format == Format.TwosComplement)
            {
                int summ = 0;
                for (int i = 1; i < Lib.Computer.Byte.BYTE_SIZE; i++)
                {
                    if (this[0])
                    {
                        if (!this[i])
                        {
                            summ += (int)Math.Pow(2, Lib.Computer.Byte.BYTE_SIZE - i - 1);
                        }
                    }
                    else
                    {
                        if (this[i])
                        {
                            summ += (int)Math.Pow(2, Lib.Computer.Byte.BYTE_SIZE - i - 1);
                        }
                    }
                }

                if (this[0])
                {
                    summ++;
                    summ *= -1;
                }

                //MessageBox.Show("ffd " +summ + "");
                return summ;
            }
            else
            {



                int summ = 0;
                for (int i = 1; i < BYTE_SIZE; i++)
                {
                    if (this[i])
                    {
                        summ += (byte)Math.Pow(2, BYTE_SIZE - i - 1);
                    }
                }

                /*
                if (format == Format.SignAndMagnitude)
                {
                    if (this[0])
                    {
                        summ *= -1;
                    }
                }

                if (format == Format.OnesComplement){
                    if (this[0])
                    {
                        summ = ~summ;

                        summ *= -1;

                    }
                }
                 */

                if (format == Format.Classic)
                {
                    if (this[0])
                    {
                        summ += (byte)Math.Pow(2, BYTE_SIZE - 1);
                    }
                }

                //MessageBox.Show(summ+"");

                return summ;
            }
        }





        public static Byte Xor(Byte a, Byte b)
        {
            Byte result = new Byte();
            for (int i = 0; i < BYTE_SIZE; i++)
            {
                result[i] = a[i] ^ b[i];
            }
            return result;
        }

        public static Byte And(Byte a, Byte b)
        {
            Byte result = new Byte();
            for (int i = 0; i < BYTE_SIZE; i++)
            {
                result[i] = a[i] && b[i];
            }
            return result;
        }


        public static Byte Or(Byte a, Byte b)
        {
            Byte result = new Byte();
            for (int i = 0; i < BYTE_SIZE; i++)
            {
                result[i] = a[i] || b[i];
            }
            return result;
        }

        public static Byte Eqv(Byte a, Byte b)
        {
            Byte result = new Byte();
            for (int i = 0; i < BYTE_SIZE; i++)
            {
                result[i] = a[i] == b[i];
            }
            return result;
        }

        public static Byte Not(Byte a)
        {
            Byte result = new Byte();
            for (int i = 0; i < BYTE_SIZE; i++)
            {
                result[i] = a[i] ^ true;
            }
            return result;
        }


        public static Byte Imp(Byte a, Byte b)
        {
            Byte result = new Byte();
            for (int i = 0; i < BYTE_SIZE; i++)
            {
                result[i] = (a[i] ^ true) || b[i];
            }
            return result;
        }

        public string HexString
        {
            get
            {
                int value = Value(Format.Classic);
                return Utils.Utils.hexAlphabet[value / Utils.Utils.hexAlphabet.Length] + "" + Utils.Utils.hexAlphabet[value % Utils.Utils.hexAlphabet.Length];
            }
        }

        public Byte Copy()
        {
            return new Byte(array);
        }

        private static void Test()
        {
            /*
            //TODO make private
            for (int i = 0; i < 128; i++)
            {
                sbyte value = (sbyte)i;
                Byte bt = new Byte(value);

                if (bt.Value(Format.SignAndMagnitude) != value)
                {
                    throw new Exception("Shit: Value(" + value + ") = " + bt.Value(Format.SignAndMagnitude));
                }
            }


            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    Byte a = new Byte((byte)i);
                    Byte b = new Byte((byte)j);

                    if (Byte.Xor(a, b).Value(Format.SignAndMagnitude) != (i ^ j))
                    {
                        throw new Exception(i + " xor " + j + " = " + (i ^ j) + ", not" + Byte.Xor(a, b).Value(Format.SignAndMagnitude));
                    }

                    if (Byte.And(a, b).Value(Format.SignAndMagnitude) != (i & j))
                    {
                        throw new Exception(i + " and " + j + " = " + (i & j) + ", not" + Byte.And(a, b).Value(Format.SignAndMagnitude));
                    }

                    if (Byte.Or(a, b).Value(Format.SignAndMagnitude) != (i | j))
                    {
                        throw new Exception(i + " or " + j + " = " + (i | j) + ", not" + Byte.Or(a, b).Value(Format.SignAndMagnitude));
                    }
                }
            }
             * */
        }
    }
}
