using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Computer.Commands.If.ExpressionsParsing;
using System.Windows.Forms;

namespace Lib.Computer.Commands
{
    public class IF : Command
    {
        public IF(string address)
        {
            args[0] = address;
            arity = 1;
        }

        public override string Syntax
        {
            get
            {
                return "IF [bool]condition";
            }
        }

        public override string Description
        {
            get
            {
                return "if(condition) {";
            }
        }

        public override string Type()
        {
            return "IF";
        }

        private bool ParseLogicExpression()
        {
            return true;
        }

        public static Expression GetExpression(string arg)
        {
            arg = arg.Substring(arg.IndexOf("<") + 1, arg.IndexOf(">") - arg.IndexOf("<") - 1);
            Expression expression = new Expression(arg);
            return expression;
        }

        public override void Execution(Computer computer)
        {
            int balance = 1;
            bool go = false;
 
            /*
            IF ({00} = {00})
              WRITE hello
            ENDIF
             */

            if (args[0].IndexOf("<") != -1)
            {
                Expression expression = GetExpression(args[0]);
                double value = expression.Calculate(computer);
                if (value == 0)
                {
                    go = true;
                }
                else 
                {
                    go = false;
                }
            }
            else
            {
                long value = Utils.Utils.OctoToLong(Utils.Utils.ParseAddress(args[0], computer));
                go = value == 0;
            }

            if (go)
            {
                for (int i = this.number+1; i < computer.program.program.Count; i++)
                {
                    Command command = computer.program.program[i];

                    if (command.Type() == new IF("").Type())
                    {
                        balance++;
                    }

                    if (command.Type() == new ENDIF().Type())
                    {
                        balance--;
                        if (balance == 0)
                        {
                            computer.currentCommand = i - 1;
                            return;
                        }
                    }
                }

                throw new Exception();
            }
            else { 
               
            }
        }
    }
}
