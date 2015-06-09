using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    class Value : Element
    {
        public string value;
        public static string left = "{";
        public static string right = "}";
        public Value(string value)
        {
            this.value = value;
        }

        //00001111
        //00110011
        //01010101
        //00111100
        //10010110

        public static bool Equal(double a, double b)
        {
            //MessageBox.Show(Math.Abs(a - b)+"");
            if (a == b)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public double GetValue(Computer computer)
        {
            if (value.IndexOf(left) != -1)
            {
                string address = value.Substring(value.IndexOf(left) + 1, value.IndexOf(right) - value.IndexOf(left) - 1);

                if (address.IndexOf("[") == -1)
                {
                    //MessageBox.Show(Utils.Utils.ParseAddress(address, computer)+"");
                    if (address[0] == '#')
                    {
                        return Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(address.Substring(1), computer));
                    }
                    else 
                    {
                        return Utils.Utils.OctoToDouble(Utils.Utils.ParseAddress(address, computer));
                    }
                }
                else
                {
                    Byte bt = Utils.Utils.ParseByteAddress(address, computer);
                    return bt.Value(Format.TwosComplement);
                }
            }
            else
            {
                return double.Parse(value);
            }
        }

        public override string ToString()
        {
            return " " + value.ToString() + " ";
        }
    }
}
