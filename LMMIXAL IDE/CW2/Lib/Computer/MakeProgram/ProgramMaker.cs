using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Computer.Commands;
using Lib.Computer.Commands.GOTO;
using Lib.Computer.Commands.LongArithmeticCommands;
using Lib.Computer.Commands.ByteArithmeticCommands;
using Lib.Computer.Commands.If;
using Lib.Computer.Commands.OctoBoolCommands;
using Lib.Computer.Commands.ConsolelCommands;
using System.Windows.Forms;
using Lib.Computer.Commands.If.ExpressionsParsing;

namespace Lib.Computer.MakeProgram
{
    public class ProgramMaker
    {
        public static char DELIMITER = ' ';
        public static string COMMENT = "//";

        public static string InsertTraps(string text)
        {
            string[] array = text.Split('\n');
            string[] newArray = new string[array.Length * 2];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    newArray[i] = array[i / 2];
                }
                else
                {
                    newArray[i] = new TRAP().Type();
                }
            }

            string newText = "";
            for (int i = 0; i < newArray.Length; i++)
            {
                newText += newArray[i] + "\n";
            }

            return newText;
        }

        public static Program Make(string text, Computer computer)
        {
            //text = Utils.Utils.DeleteSpaces(text);
            List<Command> list = new List<Command>();
            List<KeyValuePair<string, int>> errors = new List<KeyValuePair<string, int>>();
            string[] array = text.Split('\n');
            int count = 0;

            if (text.IndexOf("HALT") == -1)
            {
                errors.Add(new KeyValuePair<string,int>(count + ") Where is HALT?", 0));
                count++;
            }

            Program res = new Program();

            for (int i = 0; i < array.Length; i++)
            {
                int lastSize = list.Count;

                string record = array[i];
                record = record.Trim();
                if (record.IndexOf(COMMENT) != -1)
                {
                    record = record.Substring(0, record.IndexOf(COMMENT));
                }

                record = Utils.Utils.NormaliseString(record);

                //MessageBox.Show(record);

                if (record.Length == 0)
                {
                    list.Add(new Empty());
                }

                string[] items = record.Split(DELIMITER);
                string name = items[0];

                string arg1 = "";
                string arg2 = "";
                string arg3 = "";



                string[] args = new string[0];
                if (items.Length >= 2)
                {
                    args = new string[items.Length - 2];
                    for (int j = 0; j < items.Length - 2; j++)
                    {
                        args[j] = items[j + 2];
                    }
                }

                if (items.Length > 1)
                {
                    arg1 = items[1];
                }

                if (items.Length > 2)
                {
                    arg2 = items[2];
                }

                if (items.Length > 3)
                {
                    arg3 = items[3];
                }

                //MessageBox.Show(arg1);

                if ((new DADD("", "").Type()) == name)
                {
                    list.Add(new DADD(arg1, arg2));
                }

                if ((new DDIV("", "").Type()) == name)
                {
                    list.Add(new DDIV(arg1, arg2));
                }

                if ((new DLOG("", "").Type()) == name)
                {
                    list.Add(new DLOG(arg1, arg2));
                }

                if ((new DMOD("", "").Type()) == name)
                {
                    list.Add(new DMOD(arg1, arg2));
                }

                if ((new DMULT("", "").Type()) == name)
                {
                    list.Add(new DMULT(arg1, arg2));
                }

                if ((new DPOW("", "").Type()) == name)
                {
                    list.Add(new DPOW(arg1, arg2));
                }

                if ((new DSQRT("", "").Type()) == name)
                {
                    list.Add(new DSQRT(arg1, arg2));
                }

                if ((new DSUB("", "").Type()) == name)
                {
                    list.Add(new DSUB(arg1, arg2));
                }


                if ((new POP().Type()) == name)
                {
                    list.Add(new POP());
                }

                if ((new PUSH("").Type()) == name)
                {
                    list.Add(new PUSH(arg1));
                }


                if ((new CEIL("").Type()) == name)
                {
                    list.Add(new CEIL(arg1));
                }

                if ((new EXPR("", "").Type()) == name)
                {
                    list.Add(new EXPR(arg1, arg2));
                }

                if ((new FLOOR("").Type()) == name)
                {
                    list.Add(new FLOOR(arg1));
                }

                if ((new WRITELN("").Type()) == name)
                {
                    list.Add(new WRITELN(arg1));
                }




                if ((new LADD("", "").Type()) == name)
                {
                    list.Add(new LADD(arg1, arg2));
                }

                if ((new LDIV("", "").Type()) == name)
                {
                    list.Add(new LDIV(arg1, arg2));
                }

                if ((new LMOD("", "").Type()) == name)
                {
                    list.Add(new LMOD(arg1, arg2));
                }

                if ((new LMULT("", "").Type()) == name)
                {
                    list.Add(new LMULT(arg1, arg2));
                }

                if ((new LPOW("", "").Type()) == name)
                {
                    list.Add(new LPOW(arg1, arg2));
                }

                if ((new LSUB("", "").Type()) == name)
                {
                    list.Add(new LSUB(arg1, arg2));
                }






                if ((new BADD("", "").Type()) == name)
                {
                    list.Add(new BADD(arg1, arg2));
                }

                if ((new BDIV("", "").Type()) == name)
                {
                    list.Add(new BDIV(arg1, arg2));
                }

                if ((new BMOD("", "").Type()) == name)
                {
                    list.Add(new BMOD(arg1, arg2));
                }

                if ((new BMULT("", "").Type()) == name)
                {
                    list.Add(new BMULT(arg1, arg2));
                }

                if ((new BPOW("", "").Type()) == name)
                {
                    list.Add(new BPOW(arg1, arg2));
                }

                if ((new BSUB("", "").Type()) == name)
                {
                    list.Add(new BSUB(arg1, arg2));
                }




                if ((new IF("").Type() == name))
                {
                    list.Add(new IF(arg1));
                }

                if ((new ENDIF().Type() == name))
                {
                    list.Add(new ENDIF());
                }





                if ((new CALL("", new string[] { }).Type()) == name)
                {
                    list.Add(new CALL(arg1, args));
                }

                if ((new RET().Type()) == name)
                {
                    list.Add(new RET());
                }

                if ((new SUB("").Type()) == name)
                {
                    list.Add(new SUB(arg1));
                }

                if ((new IS("", "").Type()) == name)
                {
                    list.Add(new IS(arg1, arg2));
                }




                if ((new ANDO("", "").Type()) == name)
                {
                    list.Add(new ANDO(arg1, arg2));
                }

                if ((new EQVO("", "").Type()) == name)
                {
                    list.Add(new EQVO(arg1, arg2));
                }

                if ((new NANDO("", "").Type()) == name)
                {
                    list.Add(new NANDO(arg1, arg2));
                }

                if ((new NORO("", "").Type()) == name)
                {
                    list.Add(new NORO(arg1, arg2));
                }

                if ((new ORO("", "").Type()) == name)
                {
                    list.Add(new ORO(arg1, arg2));
                }

                if ((new XORO("", "").Type()) == name)
                {
                    list.Add(new XORO(arg1, arg2));
                }

                if ((new NOT("").Type()) == name)
                {
                    list.Add(new NOT(arg1));
                }



                if ((new RANDOML("", "", "").Type()) == name)
                {
                    list.Add(new RANDOML(arg1, arg2, arg3));
                }

                if ((new RANDOMB("", "", "").Type()) == name)
                {
                    list.Add(new RANDOMB(arg1, arg2, arg3));
                }

                if ((new RANDOMD("").Type()) == name)
                {
                    list.Add(new RANDOMD(arg1));
                }


                if ((new PAUSE("").Type()) == name)
                {
                    list.Add(new PAUSE(arg1));
                }

                if ((new LTOD("").Type()) == name)
                {
                    list.Add(new LTOD(arg1));
                }

                if ((new DTOL("").Type()) == name)
                {
                    list.Add(new DTOL(arg1));
                }


                if ((new ROUND("", "").Type()) == name)
                {
                    list.Add(new ROUND(arg1, arg2));
                }

                if ((new LEQUAL("", "", "").Type()) == name)
                {
                    list.Add(new LEQUAL(arg1, arg2, arg3));
                }

                if ((new LMORE("", "", "").Type()) == name)
                {
                    list.Add(new LMORE(arg1, arg2, arg3));
                }

                if ((new LLESS("", "", "").Type()) == name)
                {
                    list.Add(new LLESS(arg1, arg2, arg3));
                }



                if ((new DEQUAL("", "", "").Type()) == name)
                {
                    list.Add(new DEQUAL(arg1, arg2, arg3));
                }

                if ((new DMORE("", "", "").Type()) == name)
                {
                    list.Add(new DMORE(arg1, arg2, arg3));
                }

                if ((new DLESS("", "", "").Type()) == name)
                {
                    list.Add(new DLESS(arg1, arg2, arg3));
                }




                if ((new BEQUAL("", "", "").Type()) == name)
                {
                    list.Add(new BEQUAL(arg1, arg2, arg3));
                }

                if ((new BMORE("", "", "").Type()) == name)
                {
                    list.Add(new BMORE(arg1, arg2, arg3));
                }

                if ((new BLESS("", "", "").Type()) == name)
                {
                    list.Add(new BLESS(arg1, arg2, arg3));
                }




                if ((new IN("", "").Type()) == name)
                {
                    list.Add(new IN(arg1, arg2));
                }

                if ((new MOV("", "").Type()) == name)
                {
                    list.Add(new MOV(arg1, arg2));
                }

                if ((new HALT().Type() == name))
                {
                    list.Add(new HALT());
                }

                if ((new CLRMEMORY().Type() == name))
                {
                    list.Add(new CLRMEMORY());
                }

                if ((new TRAP().Type() == name))
                {
                    list.Add(new TRAP());
                }



                if ((new INC("").Type() == name))
                {
                    list.Add(new INC(arg1));
                }

                if ((new DEC("").Type() == name))
                {
                    list.Add(new DEC(arg1));
                }


                if (new SHL("", "").Type() == name)
                {
                    list.Add(new SHL(arg1, arg2));
                }

                if (new SHR("", "").Type() == name)
                {
                    list.Add(new SHR(arg1, arg2));
                }


                if (new INB("").Type() == name)
                {
                    list.Add(new INB(arg1));
                }

                if (new OUTB("").Type() == name)
                {
                    list.Add(new OUTB(arg1));
                }



                if ((new Lib.Computer.Commands.ConsolelCommands.WRITE("").Type() == name))
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.WRITE(arg1));
                }

                if ((new Lib.Computer.Commands.GOTO.LABEL("").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.GOTO.LABEL(arg1));
                }

                if ((new Lib.Computer.Commands.GOTO.GOTO("").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.GOTO.GOTO(arg1));
                }

                if ((new Lib.Computer.Commands.GOTO.GOTONEG("", "").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.GOTO.GOTONEG(arg1, arg2));
                }

                if ((new Lib.Computer.Commands.GOTO.GOTOPOS("", "").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.GOTO.GOTOPOS(arg1, arg2));
                }

                if ((new Lib.Computer.Commands.GOTO.GOTOZERO("", "").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.GOTO.GOTOZERO(arg1, arg2));
                }


                if ((new Lib.Computer.Commands.ConsolelCommands.IND("").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.IND(arg1));
                }

                if ((new Lib.Computer.Commands.ConsolelCommands.INL("").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.INL(arg1));
                }

                if ((new Lib.Computer.Commands.ConsolelCommands.INH("").Type()) == name)
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.INH(arg1));
                }



                if ((new Lib.Computer.Commands.ConsolelCommands.OUTD("").Type() == name))
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.OUTD(arg1));
                }

                if ((new Lib.Computer.Commands.ConsolelCommands.OUTL("").Type() == name))
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.OUTL(arg1));
                }

                if ((new Lib.Computer.Commands.ConsolelCommands.OUTH("").Type() == name))
                {
                    list.Add(new Lib.Computer.Commands.ConsolelCommands.OUTH(arg1));
                }

                int newSize = list.Count;

                if (newSize == lastSize)
                {
                    if (text.Split('\n')[i].TrimStart().Substring(0, 2) != "//")
                    {
                        errors.Add(new KeyValuePair<string,int>(count + ") Unexpected command in the line " + i + ": \"" + text.Split('\n')[i] + "\"", i));
                        count++;
                    }
                }

                if (newSize - lastSize > 1)
                {
                    errors.Add(new KeyValuePair<string,int>(count + ") What the hell in the line " + i + ": \"" + text.Split('\n')[i] + "\"?", i));
                    count++;
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].arity; j++)
                {
                    if (list[i].args[j] == "")
                    {
                        errors.Add(new KeyValuePair<string,int>(count + ") Invalid number of arguments in line " + i + " \"" + text.Split('\n')[i] + "\"", i));
                        count++;
                    }
                }
            }

            int balance = 0;
            for (int i = 0; i < list.Count; i++)
            {
                Command command = list[i];

                if (command.Type() == new IF("").Type())
                {
                    balance++;
                }

                if (command.Type() == new ENDIF().Type())
                {
                    balance--;
                }

                if (balance < 0)
                {
                    errors.Add(new KeyValuePair<string,int>(count + ") Number of ENDIFs more then number of IFs in the line " + i + " \"" + text.Split('\n')[i] + "\"", i));
                    count++;
                    break;
                }
            }

            res.program = list;
            res.SetVars();
            computer.program = res;

            for (int i = 0; i < list.Count; i++)
            {
                Command command = list[i];
                if (command.Type() == new GOTO("").Type() || command.Type() == new GOTOPOS("", "").Type() || command.Type() == new GOTONEG("", "").Type() || command.Type() == new GOTOZERO("", "").Type())
                {
                    bool isFound = false;
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Type() == new LABEL("").Type())
                        {
                            if (command.args[0] == list[j].args[0])
                            {
                                isFound = true;
                                break;
                            }
                        }
                    }

                    if (!isFound)
                    {
                        errors.Add(new KeyValuePair<string,int>(count + ") There is no label for command in the line " + i + " \"" + text.Split('\n')[i] + "\"", i));
                        count++;
                    }
                }

                if (command.Type() == new IF("").Type())
                {
                   try
                   {
                      Expression expression = IF.GetExpression(command.args[0]);
                      expression.Calculate(computer);
                   }
                   catch(Exception e)
                   {
                      errors.Add(new KeyValuePair<string,int>(count + ") Cannot parse " + command.args[0] + " in the line "+i+" \"" + text.Split('\n')[i] + "\" Have you forgotten <> or {}?", i));
                      count++;
                   }
                }


                if (command.Type() == new EXPR("", "").Type())
                {
                    try
                    {
                        Expression expression = IF.GetExpression(command.args[1]);
                        expression.Calculate(computer);
                    }
                    catch (Exception e)
                    {
                        errors.Add(new KeyValuePair<string, int>(count + ") Cannot parse " + command.args[0] + " in the line " + i + " \"" + text.Split('\n')[i] + "\" Have you forgotten <> or {}?", i));
                        count++;
                    }
                }
            }

            //res.program = list;
            //res.SetVars();
            //computer.program = res;
           

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].octoArgs.Count; j++)
                {
                    try
                    {
                        Utils.Utils.ParseAddress(list[i].args[list[i].octoArgs[j]], computer);
                    }
                    catch (Exception e)
                    {
                        errors.Add(new KeyValuePair<string,int>(count + ") Unexpected octo value " + list[i].args[list[i].octoArgs[j]] + " in the line " + i + " \"" + text.Split('\n')[i] + "\"", i));
                        count++;
                    }
                }

                for (int j = 0; j < list[i].byteArgs.Count; j++)
                {
                    try
                    {
                        Utils.Utils.ParseByteAddress(list[i].args[list[i].byteArgs[j]], computer);
                    }
                    catch (Exception e)
                    {
                        errors.Add(new KeyValuePair<string,int>(count + ") Unexpected byte value " + list[i].args[list[i].byteArgs[j]] + " in the line " + i + " \"" + text.Split('\n')[i] + "\"", i));
                        count++;
                    }
                }


                for (int j = 0; j < list[i].hexArgs.Count; j++)
                {
                    string arg = list[i].args[list[i].hexArgs[j]];
                    bool isNormal = true;
                    for (int k = 0; k < arg.Length; k++)
                    {
                        if ((arg[k] >= '0' && arg[k] <= '9') || (arg[k] >= 'A' && arg[k] <= 'F'))
                        {
                        }
                        else
                        {
                            isNormal = false;
                        }
                    }

                    if (arg.Length > 16 || !isNormal)
                    {
                        errors.Add(new KeyValuePair<string,int>(count + ") Invalid hex value " + arg + " in the line " + i + " \"" + text.Split('\n')[i] + "\"", i));
                        count++;
                    }
                }
            }


            res.errors = errors;
            return res;
        }


    }
}
