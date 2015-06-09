using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Computer;
using System.Windows.Forms;

namespace Lib.Utils
{
    public class Utils
    {
        public static int orderLength = 11;
        public static int mantissLength = 52;
        public static int orderOffcet = 1023;

        public static string hexAlphabet = "0123456789ABCDEF";
        public static string Reverse(string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static int HexToInt(string hex)
        {
            hex = hex.ToUpper();

            int summ = 0;

            for (int i = 0; i < hex.Length; i++)
            {
                int index = i;
                int weight = (int)Math.Pow(16, hex.Length - index - 1);
                summ += hexAlphabet.IndexOf(hex[index]) * weight;
            }

            return summ;
        }

        public static string IntToHex(int number, int length)
        {
            string res = String.Format("{0:X}", number);
            res = new string('0', length - res.Length) + res;
            res = res.ToUpper();
            return res;
        }

        public static double OctoToDouble(OctoByte octo)
        {
            bool[] bits = octo.GetBits();
            double sign = bits[0] ? -1 : 1;

            bool[] orderArray = new bool[orderLength];
            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i] = bits[i + 1];
            }
            double order = BinaryValue(orderArray) - orderOffcet;

            bool[] mantissArray = new bool[mantissLength];
            for (int i = 0; i < mantissArray.Length; i++)
            {
                mantissArray[i] = bits[i + 1 + orderLength];
            }
            double mantiss = BinaryValue(mantissArray) / Math.Pow(2, mantissLength) + 1;

            /*
            if (order == -orderOffcet)
            {
                return sign * (mantiss - 1) * Math.Pow(2, order + 1);
            }
             * */

            if (octo.Equals(new OctoByte("0000000000000000")))
            {
                return 0;
            }

            if (octo.Equals(new OctoByte("7FF0000000000000")))
            {
                return Double.PositiveInfinity;
            }

            if (octo.Equals(new OctoByte("FFF0000000000000")))
            {
                return Double.NegativeInfinity;
            }

            if (octo.Equals(new OctoByte("7FFFFFFFFFFFFFFF")))
            {
                return Double.NaN;
            }

            return sign * mantiss * Math.Pow(2, order);
        }

        public static Lib.Computer.Computer PutInAddress(string address, Lib.Computer.Computer computer, string hex)
        {  
            if(hex == "PEEK")
            {
                hex = computer.Peek();
            }
            
            address = NormaliseAddress(address, computer);

            if (address.IndexOf("$") != -1)
            {
                int index = HexToInt(address.Substring(1));
                computer.memory.SetRegister(index, new OctoByte(hex));
            }
            else
            {
                int index = HexToInt(address); 
                computer.memory[index] = new OctoByte(hex);
            }
            return computer;
        }

         
        public static Lib.Computer.Computer PutInAddress(string address, Lib.Computer.Computer computer, OctoByte octo)
        {
            address = NormaliseAddress(address, computer);

            if (address.IndexOf("$") != -1)
            {
                int index = HexToInt(address.Substring(1));
                computer.memory.SetRegister(index, octo);
            }
            else
            {
                int index = HexToInt(address); ;
                computer.memory[index] = octo;
            }
            return computer;
        }

        public static string NormaliseString(string record) 
        {
            char leftBracket = '<';
            char rightBracket = '>';
            int balance = 0;
            string newString = "";
            for (int i = 0; i < record.Length; i++ )
            {
                if (record[i] == leftBracket)
                {
                    balance++;
                }

                if (record[i] == rightBracket)
                {
                    balance--;
                }

                if (balance > 0)
                {
                    if (record[i] == ' ')
                    {

                    }
                    else 
                    {
                        newString += record[i];
                    }
                }
                else 
                {
                    newString += record[i];
                }
            }

            record = newString;

            for (int j = 2; j < 10; j++)
            {
                record = record.Replace(new string(' ', j), " ");
            }
            return record;
        }

        public static OctoByte ParseAddress(string address, Lib.Computer.Computer computer)
        {
            
            if(address == "PEEK")
            {
                MessageBox.Show(computer.Peek());
                return ParseAddress(computer.Peek(), computer);
            }
            

            address = NormaliseAddress(address, computer);

            if (address.IndexOf("$") != -1)
            {
                return computer.memory.GetRegister(HexToInt(address.Substring(1)));
            }
            else
            {
                int hti = HexToInt(address);
                return computer.memory[hti];
            }
        }

        public static bool Not(bool a) 
        {
            return a==false;
        }

        public static Lib.Computer.Byte ParseByteAddress(string address, Lib.Computer.Computer computer) 
        {
            string octoAddress = address.Substring(0,address.IndexOf("["));
            OctoByte octo = ParseAddress(octoAddress, computer);
            string indexAddress = address.Substring(address.IndexOf("[")+1, address.IndexOf("]") - address.IndexOf("[") - 1);
            
            //MessageBox.Show(indexAddress + "");

            long index = 0;
            if (Not(indexAddress.IndexOf("*") == -1))
            {
                index = Utils.OctoToLong(Utils.ParseAddress(indexAddress.Substring(1), computer));
            }
            else 
            {
                index = Utils.HexToInt(indexAddress);
            }

            //MessageBox.Show(index+"");

            return octo[(int)index];
        }


        public static void PutInByteAddress(string address, Lib.Computer.Computer computer, Lib.Computer.Byte value)
        {
            Lib.Computer.Byte cell = ParseByteAddress(address, computer);
            for (int i = 0; i < Lib.Computer.Byte.BYTE_SIZE; i++ )
            {
                cell[i] = value[i];
            }
        }

        public static OctoByte DoubleToOcto(double value)
        {
            if (value == Double.NaN)
            {
                return new OctoByte("7FFFFFFFFFFFFFFF");
            }

            if (value == Double.PositiveInfinity)
            {
                return new OctoByte("7FF0000000000000");
            }

            if (value == Double.NegativeInfinity)
            {
                return new OctoByte("FFF0000000000000");
            }

            if (value == 0)
            {
                return new OctoByte("0000000000000000");
            }


            int order = 0;
            bool sign = value < 0;
            value = Math.Abs(value);
            double mantiss = value;

            if (value >= 2)
            {
                double temp = value;
                int i = 0;
                while (temp >= 2)
                {
                    temp /= 2;
                    i++;
                }
                order = i;
                mantiss = temp;
            }

            if (value == 1)
            {
                order = 0;
                mantiss = 1;
            }

            if (value < 1)
            {
                double temp = value;
                int i = 0;
                while (temp < 1)
                {
                    temp *= 2;
                    i++;
                }
                order = -i;
                mantiss = temp;
            }

            order += orderOffcet;
            mantiss -= 1;

            bool[] orderArray = new bool[orderLength];
            string orderString = Convert.ToString(order, 2);
            orderString = new string('0', orderLength - orderString.Length) + orderString;
            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i] = orderString[i] == '1';
            }

            long intMantiss = (long)(mantiss * Math.Pow(2, mantissLength));
            bool[] mantissArray = new bool[mantissLength];
            string mantissString = Convert.ToString(intMantiss, 2);

            try
            {
                mantissString = new string('0', mantissLength - mantissString.Length) + mantissString;
            }
            catch(Exception e)
            {
                MessageBox.Show(value+" "+mantiss);
            }

            for (int i = 0; i < mantissArray.Length; i++)
            {
                mantissArray[i] = mantissString[i] == '1';
            }

            bool[] newArray = new bool[1 + orderLength + mantissLength];
            newArray[0] = sign;
            for (int i = 0; i < orderArray.Length; i++)
            {
                newArray[i + 1] = orderArray[i];
            }
            for (int i = 0; i < mantissArray.Length; i++)
            {
                newArray[i + 1 + orderArray.Length] = mantissArray[i];
            }

            OctoByte res = new OctoByte();
            for (int i = 0; i < OctoByte.OCTO_SIZE; i++)
            {
                for (int j = 0; j < Lib.Computer.Byte.BYTE_SIZE; j++)
                {
                    int index = i * Lib.Computer.Byte.BYTE_SIZE + j;
                    res[i][j] = newArray[index];
                }
            }

            return res;
        }


        public static long OctoToLong(OctoByte octo)
        {
            long summ = 0;
            for (int i = 1; i < Lib.Computer.Byte.BYTE_SIZE * OctoByte.OCTO_SIZE; i++)
            {

                if (octo[0][0])
                {
                    if (!octo[i / OctoByte.OCTO_SIZE][i % OctoByte.OCTO_SIZE])
                    {
                        summ += (long)Math.Pow(2, Lib.Computer.Byte.BYTE_SIZE * OctoByte.OCTO_SIZE - i - 1);
                    }
                }
                else
                {
                    if (octo[i / OctoByte.OCTO_SIZE][i % OctoByte.OCTO_SIZE])
                    {
                        summ += (long)Math.Pow(2, Lib.Computer.Byte.BYTE_SIZE * OctoByte.OCTO_SIZE - i - 1);
                    }
                }

            }

            if (octo[0][0])
            {
                summ++;
                summ *= -1;
            }
            return summ;
        }

        public static OctoByte LongToOcto(long value)
        {
            string str = Convert.ToString(value, 2);
            str = new string('0', Lib.Computer.Byte.BYTE_SIZE * OctoByte.OCTO_SIZE - str.Length) + str;
            OctoByte res = new OctoByte();
            bool[] bits = new bool[OctoByte.OCTO_SIZE * Lib.Computer.Byte.BYTE_SIZE];


            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] = str[i] == '1';
            }



            for (int i = 0; i < OctoByte.OCTO_SIZE; i++)
            {
                for (int j = 0; j < Lib.Computer.Byte.BYTE_SIZE; j++)
                {
                    res[i][j] = bits[i * Lib.Computer.Byte.BYTE_SIZE + j];
                }
            }

            return res;
        }

        public static double BinaryValue(bool[] array)
        {
            double res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i])
                {
                    res += Math.Pow(2, array.Length - i - 1);
                }
            }
            return res;
        }

        public static string BoolToString(bool a)
        {
            if (a)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static string DeleteSpaces(string s)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    res += s[i];
                }
            }
            return res;
        }

        public static string NormaliseAddress(string address, Computer.Computer computer) 
        {
            if(address[0] == '*')
            {
                string value = address.Substring(1);
                address = Convert.ToString(OctoToLong(ParseAddress(value, computer)), 16).ToUpper();
            }

            for (int i = 0; i < computer.program.vars.Count; i++)
            {
                string name = computer.program.vars[i].Key;
                string value = computer.program.vars[i].Value;
                if (address == name)
                {
                    address = value;
                }
            }

            return address;
        }
    }
}
