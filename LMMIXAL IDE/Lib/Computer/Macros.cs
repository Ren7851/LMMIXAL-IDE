using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lib.Computer
{
    public class Macros
    {
        List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
        private static Macros instance;


        private Macros()
        {
            
        }

        public static Macros GetInstance() 
        {
            if (instance == null)
            {
                instance = new Macros();
                return instance;
            }
            else 
            {
                return instance;
            }
        }

        public void Set(string file)
        {
            pairs = new List<KeyValuePair<string, string>>();
            string[] array = File.ReadAllLines(file);
            string sign = "->";
            for (int i = 0; i < array.Length; i++ )
            {
                if(array[i].IndexOf(sign) != -1)
                {
                    string key = array[i].Substring(0, array[i].IndexOf(sign));
                    string value = array[i].Substring(array[i].IndexOf(sign) + sign.Length);
                    pairs.Add(new KeyValuePair<string, string>(key, value));
                }
            }
        }

        public string Substitute(string text)
        {
            string res = text;
            for(int i = 0; i<pairs.Count; i++)
            {
                res = res.Replace(pairs[i].Key, pairs[i].Value);
            }
            return res;
        }
    }
}
