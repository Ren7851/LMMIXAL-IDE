using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Computer.Commands.If.ExpressionsParsing;
using System.Windows.Forms;
using System.Collections.Concurrent;


namespace Lib.Computer.Commands.If.ExpressionsParsing
{
    public class Expression
    {
        List<Element> list = new List<Element>();
        List<Element> output = new List<Element>();
        List<Operation> operationsList = new List<Operation>();
        public Expression(string str)
        {
            str = Utils.Utils.NormaliseString(str);
            str = str.Replace("(", " ( ");
            str = str.Replace(")", " ) ");

            operationsList.Add(new OperationAdd());
            operationsList.Add(new OperationSub());
            operationsList.Add(new OperationDiv());
            operationsList.Add(new OperationMult());
            operationsList.Add(new OperationEqual());
            operationsList.Add(new OperationMoreEqual());
            operationsList.Add(new OperationLessEqual());
            operationsList.Add(new OperationMore());
            operationsList.Add(new OperationLess());
            operationsList.Add(new OperationNot());
            operationsList.Add(new OperationAnd());
            operationsList.Add(new OperationOr());
            operationsList.Add(new OperationMod());
            operationsList.Add(new OperationPow());

            for (int i = 0; i < operationsList.Count; i++ )
            {
                str = str.Replace(operationsList[i].symbol, " " + operationsList[i].symbol+" ");
            }
            string[] spl = str.Split(' ');

            for (int i = 0; i < spl.Length; i++)
            {
                if(spl[i] == "")
                {
                    continue;
                }

                bool fd = false;
                for (int j = 0; j < operationsList.Count; j++)
                {
                    if (spl[i] == operationsList[j].GetSymbol())
                    {
                        list.Add(operationsList[j].Clone());
                        fd = true;
                        break;
                    }
                }

                if (spl[i] == "(")
                {
                    list.Add(new LeftBracket());
                    continue;
                }

                if (spl[i] == ")")
                {
                    list.Add(new RightBracket());
                    continue;
                }

                if (!fd)
                {
                    string s = spl[i];
                    list.Add(new Value(s));
                }
            }


            output = new List<Element>();

            Stack<Element> st = new Stack<Element>();
            for (int i = 0; i < list.Count; i++)
            {
                Element element = list[i];
                if (element.GetType() == new Value("0").GetType())
                {
                    output.Add(element);
                }
                else
                {
                    if (element.GetType() == new LeftBracket().GetType())
                    {
                        st.Push(element);
                        continue;
                    }

                    if (element.GetType() == new RightBracket().GetType())
                    {
                        while (st.Peek().GetType() != new LeftBracket().GetType())
                        {
                            output.Add(st.Pop());
                        }
                        st.Pop();
                        continue;
                    }

                    Operation o1 = (Operation)element;

                    if (st.Count > 0)
                    {
                        Element peek;
                        while (st.Count > 0)
                        {
                            peek = st.Peek();
                            if (peek.GetType() == new LeftBracket().GetType())
                            {
                                break;
                            }
                            else
                            {
                                Operation op = (Operation)peek;
                                if (o1.priority > op.priority)
                                {
                                    break;
                                }
                                else
                                {
                                    output.Add(st.Pop());
                                }
                            }
                        }
                    }
                    st.Push(o1);
                }
            }

            for (int i = 0; i < st.Count; i++)
            {
                output.Add(st.ElementAt(i));
            }
        }

        public double Calculate() 
        {
            return Calculate(null);
        }


        public double Calculate(Computer computer)
        {
            Stack<Element> stack = new Stack<Element>();
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i].GetType() == new Value("0").GetType())
                {
                    stack.Push(output[i]);
                }
                else
                {
                    int number = (output[i]).arity;
                    double[] array = new double[number];
                    for (int j = 0; j < number; j++)
                    {
                        Value value = (Value)stack.Pop();
                        array[j] = value.GetValue(computer);
                    }

                    Operation oper = (Operation)output[i];
                    Array.Reverse(array);
                    double res = oper.Calculate(array);
                    stack.Push(new Value(res+""));
                }
            }

            Value val = (Value)stack.Peek();
            return val.GetValue(computer);
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < output.Count; i++)
            {
                res += output[i].ToString();
            }
            return res;
        }
    }
}
