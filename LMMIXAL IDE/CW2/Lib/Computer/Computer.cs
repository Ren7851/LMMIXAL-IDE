using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Computer;
using System.Drawing;
using Lib;
using System.Text.RegularExpressions;
using Lib.Computer.Commands;
using System.Threading;

namespace Lib.Computer
{
    public class Pair
    {
        public string type;
        public int count;

        public Pair(string type, int value)
        {
            this.type = type;
            this.count = value;
        }
    }

    public class Computer
    {
        public bool isMultyThreading = false;
        public Form input;
        public int beepDuration = 80;
        public Memory memory;
        public Program program;
        public int currentCommand;
        public RichTextBox box;
        public PictureBox view;
        public RichTextBox console;
        public bool isExceptignInput = false;
        public bool isTrapped = false;
        public bool isDegugging = false;
        public Stack<string> stack;
        public ListBox stackView;
        public Random random = new Random();
        public bool fastMode = false;
        public bool isBeeps = true;
        private string message = "The exceptional situation was occured in the line ";
        public Thread thread;
        public List<Pair> executedCommands = new List<Pair>();

        public static string[] keywords;

        public void ThreadCode()
        {

        }

        public Computer(Memory memory, RichTextBox code, PictureBox view, RichTextBox console, ListBox stackView, Form input)
        {
            this.box = code;
            this.view = view;
            this.console = console;
            this.memory = memory;
            this.input = input;
            program = new Program();
            stack = new Stack<string>();
            this.stackView = stackView;
            thread = new Thread(BeginProcess);
        }

        public void AddCommand(Lib.Computer.Commands.Command command)
        {
            //command.number = program.program.Count;
            program.program.Add(command);
        }

        public void ClearCommands()
        {
            program = new Program();
        }

        public void Launch()
        {
            executedCommands = new List<Pair>();

            for (int i = 0; i < keywords.Length; i++)
            {
                executedCommands.Add(new Pair(keywords[i], 0));
            }



            this.currentCommand = 0;
            console.Text = "";
            this.program.SetVars();
            //Run("");
            if (this.isMultyThreading)
            {
                thread = new Thread(BeginProcess);
                thread.Start();
            }
            else 
            {
                Run("");
            }
        }

        public void Push(string value)
        {
            stack.Push(value);
        }

        public string Pop()
        {
            return stack.Pop().ToUpper();
        }

        public void Resume()
        {
            this.currentCommand = this.currentCommand + 1;
            //Run("");
            if (this.isMultyThreading)
            {
                thread = new Thread(BeginProcess);
                thread.Start();
            }
            else 
            {
                Run("");
            }
        }

        public void BeginProcess()
        {
            Run("");
        }

        public string Peek()
        {
            return stack.Peek();
        }

        public void Run(string userInput)
        {

            //box.Enabled = false;

            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
            box.SelectionBackColor = Color.White;

            for (int i = 0; i < program.program.Count; i++)
            {
                program.program[i].number = i;
            }

            if (program.errors.Count > 0)
            {
                console.Text = "";
                for (int i = 0; i < program.errors.Count; i++)
                {
                    console.Text += program.errors[i].Key + "\n";
                    this.ShowLine(program.errors[i].Value, Color.FromArgb(255, 100, 100));
                }
                MessageBox.Show("Program includes some errors and will not excecuted");
                return;
            }

            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
            box.SelectionBackColor = Color.White;

            string[] input = { "IND", "INH", "INL", "INB" };

            while (true)
            {
                if (fastMode == false)
                {
                    console.Refresh();
                }
                if (program.program[currentCommand].GetType() != new Lib.Computer.Commands.HALT().GetType())
                {
                    if (fastMode == false)
                    {
                        VisualizeCommand();
                        VisualizeStack();
                        view.Refresh();
                        console.Refresh();
                    }
                    //stackView.Refresh();

                    if (program.program[currentCommand].Type() == new TRAP().Type())
                    {
                        this.isTrapped = true;
                        this.isDegugging = true;
                        VisualizeCommand();
                        VisualizeStack();
                        view.Refresh();
                        console.Text += "Program was trapped\n";
                        console.Refresh();
                        return;
                    }

                    string commandType = program.program[currentCommand].Type();
                    if (Array.IndexOf(input, commandType) != -1)
                    {
                        if (userInput.Length == 0)
                        {
                            this.isExceptignInput = true;
                            PrepareConsole();
                            return;
                        }
                        else
                        {
                            if (commandType != "INB")
                            {
                                Lib.Computer.Commands.ConsolelCommands.ConsoleInputCommand command;
                                command = (Lib.Computer.Commands.ConsolelCommands.ConsoleInputCommand)(program.program[currentCommand]);
                                command.SetValue(userInput);
                            }
                            else
                            {
                                Lib.Computer.Commands.ConsolelCommands.INB command;
                                command = (Lib.Computer.Commands.ConsolelCommands.INB)(program.program[currentCommand]);
                                command.SetValue(userInput);
                            }
                            //console.Text = console.Text.Substring(0, console.Text.Length - 1);
                            this.isExceptignInput = false;
                            userInput = "";
                        }
                    }
                    try
                    {
                        for (int i = 0; i < executedCommands.Count; i++)
                        {
                            if (executedCommands[i].type == program.program[currentCommand].Type())
                            {
                                //MessageBox.Show(executedCommands[i].type);
                                executedCommands[i].count = executedCommands[i].count + 1;
                            }
                        }
                        program.program[currentCommand].Execute(this);
                    }
                    catch (InvalidOperationException e)
                    {
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "the stack is empty";
                        MessageBox.Show(message);
                        ShutDown();
                        return;
                    }
                    catch (DivideByZeroException e)
                    {
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "dividing by zero";
                        MessageBox.Show(message);
                        ShutDown();
                        return;
                    }
                    catch (ArgumentException e)
                    {
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "invalid argument";
                        MessageBox.Show(message);
                        MessageBox.Show(e.Message);
                        MessageBox.Show(e.StackTrace);
                        ShutDown();
                        return;
                    }
                    catch (Lib.Exceptions.NoSuchLabelException e)
                    {
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "there are not such label";
                        MessageBox.Show(message);
                        ShutDown();
                        return;
                    }
                    catch (Exception e)
                    {
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "some sort of magic";
                        MessageBox.Show(message);
                        ShutDown();
                        return;
                    }


                    currentCommand++;
                    if (fastMode == false)
                    {
                        box.SelectionStart = 0;
                        box.SelectionLength = box.Text.Length;
                        box.SelectionBackColor = Color.White;
                        box.Refresh();
                    }
                    //HightLight(box);
                }
                else
                {
                    console.Text += "\nTerminated\n";
                    console.Text += "Executed commands:\n";

                    for (int i = 0; i < executedCommands.Count; i++)
                    {
                        for (int j = 0; j < executedCommands.Count - 1; j++)
                        {
                            if (executedCommands[j].count < executedCommands[j + 1].count)
                            {
                                Pair temp = executedCommands[j + 1];
                                executedCommands[j + 1] = executedCommands[j];
                                executedCommands[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < executedCommands.Count; i++)
                    {
                        if (executedCommands[i].count > 0)
                        {
                            console.Text += executedCommands[i].type.PadLeft(10) + " -" + (executedCommands[i].count+"").PadLeft(5) + "\n";
                        }
                    }

                    console.Refresh();

                    VisualizeCommand();
                    VisualizeStack();
                    //stackView.Refresh();
                    view.Refresh();
                    console.Refresh();
                    program.program[currentCommand].Execute(this);
                    box.SelectionStart = 0;
                    box.SelectionLength = box.Text.Length;
                    box.SelectionBackColor = Color.White;
                    //HightLight(box);
                    box.Refresh();
                    thread.Abort();//прерываем поток
                    thread = new Thread(BeginProcess);
                    isDegugging = false;
                    //box.Enabled = true;
                    box.Refresh();

                    break;
                }
            }
        }

        public void ShutDown()
        {
            currentCommand = 0;
            VisualizeCommand();
            VisualizeStack();
            //stackView.Refresh();
            view.Refresh();
            console.Refresh();
            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
            box.SelectionBackColor = Color.White;
            //HightLight(box);
            box.Refresh();
            isDegugging = false;
            //box.Enabled = true;
        }

        public void PrepareConsole()
        {
            //MessageBox.Show("gffg");

            if (input.Visible)
            {
                input.ShowDialog();
            }
            else 
            {
                input.Visible = true;
            }

            
            //input.Clear();
            
            /*
            console.Focus();
            console.Text += ">> ";
            if (console.Text.Split('\n')[console.Text.Split('\n').Length - 1] == "")
            {
                console.Text = console.Text.Substring(console.Text.Length - 1);
            }
            console.SelectionStart = console.Text.Length;
            console.SelectionLength = 0;
            console.Focus();
             * */
        }

        public void Input()
        {
            if (isExceptignInput)
            {

            }
        }

        public void VisualizeStack()
        {
            stackView.Items.Clear();
            for (int i = 0; i < stack.Count; i++)
            {
                stackView.Items.Add(stack.ElementAt<string>(i));
            }
            stackView.Refresh();
        }

        public void VisualizeCommand()
        {
            ShowLine(currentCommand, Color.FromArgb(200, 255, 255));
        }

        public void ShowLine(int line, Color color)
        {
            int summ = 0;
            for (int i = 0; i < line; i++)
            {
                summ += box.Lines[i].Length;
                summ++;
            }

            int begin = summ;
            int end = summ + box.Lines[line].Length;
            box.SelectionStart = begin;
            box.SelectionLength = end - begin;
            box.SelectionBackColor = color;
            //box.SelectionColor = Color.FromArgb(200, 255, 255);
            box.ShowSelectionMargin = true;
            box.Refresh();
        }

        public void HightLight(RichTextBox box)
        {

            /*
            int start = box.SelectionStart;
            string text = box.Text;

            box.SelectionBackColor = Color.White;
            for (int i = 0; i < commands.Length; i++)
            {
                MatchCollection allIp = Regex.Matches(box.Text, commands[i]);
                foreach (Match ip in allIp)
                {
                    int begin = ip.Index;
                    int end = ip.Length + begin;
                    box.SelectionStart = ip.Index;
                    box.SelectionLength = ip.Length;
                    box.SelectionBackColor = Color.White;
                    box.ShowSelectionMargin = false;
                    //box.Refresh();
                    //box.SelectionColor = System.Drawing.Color.Blue;
                    //box.SelectionStart = start;
                }
                //box.SelectionLength = 0;
                //box.SelectionColor = System.Drawing.Color.Black;
            }
             * */

            /*
            int start = box.SelectionStart;
            string[] array = box.Lines;
            string[] newArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                string command = "";
                for (int j = 0; j < command.Length; j++)
                {
                    if (array[i].Contains(commands[j]))
                    {
                        command = commands[j];
                    }
                }

                if (command == "")
                {
                    newArray[i] = array[i];
                }
                else
                {
                    newArray[i] = array[i];
                   
                    //string res = "";
                    //int begin = array[i].IndexOf(command);
                    //int end = begin + command.Length;
                    //string beginColorTag = "\\colortbl \\red128\\green64\\blue128\\";
                    //string endColorTag = "\\colortbl \\red256\\green256\\blue256\\";
                    //res = array[i].Substring(0, begin) + beginColorTag + command + endColorTag + array[i].Substring(begin+command.Length);
                    //newArray[i] = res;
                    
                }
            }

            string rtf = "{\\rtf1 ";
            for (int i = 0; i < newArray.Length; i++)
            {
                if (rtf.Length != newArray.Length - 1)
                {
                    rtf += newArray[i] + " \\par ";
                }
                else 
                {
                    rtf += newArray[i];
                }
            }
            rtf += "}";
            box.SelectionStart = start;

            box.Rtf = rtf;


            box.SelectionStart = start;
             * */
            int length = box.Text.Length;

            int start = box.SelectionStart;

            string startText = box.Text.Substring(0, start);

            string beginColorTag = "\\cf2";
            string endColorTag = "\\cf1";
            string text = box.Text;
            string[] array = text.Split('\n');
            string nw = "";

            Array.Sort(keywords);

            for (int i = 0; i < array.Length; i++)
            {
                /*
                if (i == array.Length-1)
                {
                    nw += array[i] + "";
                    break;
                }
                 * */


                nw += array[i] + "\\par ";
            }

            text = nw;


            for (int i = 0; i < keywords.Length; i++)
            {
                text = text.Replace(keywords[i], beginColorTag + " " + keywords[i] + " " + endColorTag);
            }

            box.Rtf = "{\\rtf1{\\colortbl;\\red0\\green0\\blue0;\\red0\\green0\\blue255;}" + text + "} ";

            //MessageBox.Show((startText == box.Text) + "    " + startText + "   !=   " + box.Text + " " + startText.Length + " " + box.Text.Length);


            for (int i = 0; i <= box.Text.Length; i++)
            {
                //MessageBox.Show((box.Text.Substring(0, i) == startText)+" ");
                if (box.Text.Substring(0, i) == startText)
                {
                    box.SelectionStart = i;
                }
            }


        }
    }
}
