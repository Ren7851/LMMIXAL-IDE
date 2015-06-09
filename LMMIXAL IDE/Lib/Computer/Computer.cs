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
        public List<int> selectedOctos = new List<int>();
        public List<int> selectedRegisters = new List<int>();

        public bool isMultyThreading = false;
        public Form input;
        public int beepDuration = 40;
        public bool perfomanceAnalize = false;
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
        private string message = "The exceptional situation was occured on the line ";
        public Thread thread;
        public List<Pair> executedCommands = new List<Pair>();
        public bool isExecuting = false;
        private PerfomanceExplorer perfomance;

        public static string[] keywords;

        public void ThreadCode()
        {

        }

        public Computer(Memory memory, RichTextBox code, PictureBox view, RichTextBox console, ListBox stackView, Form input)
        {
            //selectedOctos.Add(1);
            //selectedRegisters.Add(0);
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
            program.setLinesPairs(box);
            executedCommands = new List<Pair>();
            for (int i = 0; i < keywords.Length; i++)
            {
                executedCommands.Add(new Pair(keywords[i], 0));
            }
            perfomance = new PerfomanceExplorer(program.program.Count);


            this.currentCommand = 0;
            console.Text = "";
            this.program.SetVars();
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

        public void MakeResume()
        {
            this.currentCommand = this.currentCommand + 1;
            this.isExecuting = true;
        }

        public void MakeLaunch()
        {
            this.isExecuting = true;
            Prepare();
        }

        public void PrepareFast()
        {
            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
            box.SelectionBackColor = Color.White;

            for (int i = 0; i < program.program.Count; i++)
            {
                program.program[i].Number = i;
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
                this.isExecuting = false;
                return;
            }



            console.Text = "";
            this.program.SetVars();
        }

        #region
        public void Prepare()
        {
            program.setLinesPairs(box);
            executedCommands = new List<Pair>();
            stack.Clear();
            for (int i = 0; i < keywords.Length; i++)
            {
                executedCommands.Add(new Pair(keywords[i], 0));
            }
            perfomance = new PerfomanceExplorer(program.program.Count);

            PrepareFast();
            this.currentCommand = 0;
        }
        #endregion

        #region
        public void Next(string userInput)
        {
            try
            {
                box.SelectionStart = 0;
                box.SelectionLength = box.Text.Length;
                box.SelectionBackColor = Color.White;
                box.Refresh();
                //Console.Beep(800, beepDuration);
                string[] input = { "IND", "INH", "INL", "INB" };
                console.Refresh();
                if (program.program[currentCommand].GetType() != new Lib.Computer.Commands.HALT().GetType())
                {
                    VisualizeCommand();
                    VisualizeStack();
                    console.Refresh();

                    if (program.program[currentCommand].Type() == new TRAP().Type())
                    {
                        this.isTrapped = true;
                        this.isDegugging = true;
                        this.isExecuting = false;
                        VisualizeCommand();
                        VisualizeStack();
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
                            this.isExecuting = false;
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
                                executedCommands[i].count = executedCommands[i].count + 1;
                            }
                        }
                        perfomance.Add(currentCommand);
                        program.program[currentCommand].Execute(this);
                        //VisualizeCommand();


                        if (fastMode == false)
                        {
                            if (isBeeps)
                            {
                                Console.Beep(600, beepDuration);
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(beepDuration);
                            }
                        }
                        //program.program[currentCommand].Execute(this);
                    }
                    catch (InvalidOperationException e)
                    {
                        message = "The exceptional situation was occured on the line ";
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "the stack is empty";
                        console.Text += message;
                        ShutDown();
                        return;
                    }
                    catch (DivideByZeroException e)
                    {
                        message = "The exceptional situation was occured on the line ";
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "dividing by zero";
                        console.Text += message;
                        ShutDown();
                        return;
                    }
                    catch (ArgumentException e)
                    {
                        message = "The exceptional situation was occured on the line ";
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "invalid argument";
                        console.Text += message;
                        ShutDown();
                        return;
                    }
                    catch (Lib.Exceptions.NoSuchLabelException e)
                    {
                        message = "The exceptional situation was occured on the line ";
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "there are not such label";
                        console.Text += message;
                        ShutDown();
                        return;
                    }
                    catch (Exception e)
                    {
                        message = "The exceptional situation was occured on the line ";
                        message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                        message += "some sort of magic";
                        console.Text += message;
                        ShutDown();
                        return;
                    }


                    currentCommand++;
                    /*
                    if (fastMode == false)
                    {
                        box.SelectionStart = 0;
                        box.SelectionLength = box.Text.Length;
                        box.SelectionBackColor = Color.White;
                        box.Refresh();
                    }
                     * */
                }
                else
                {
                    console.Text += "\nTerminated\n";
                    ShutDown();
                    PerfomanceReport();
                    console.Refresh();

                    VisualizeCommand();
                    VisualizeStack();
                    view.Refresh();
                    console.Refresh();
                    //program.program[currentCommand].Execute(this);
                    view.Refresh();
                    box.Refresh();
                    isDegugging = false;
                    box.Refresh();
                }
            }
            catch(Exception e9)
            {
                message = "The exceptional situation was occured because of ";
                message += "some sort of magic";
                console.Text += message;
                try 
                {
                    ShutDown();
                }
                catch(Exception e14)
                {
                    this.isExecuting = false;
                }
                return;
            }
        }
        #endregion

        #region
        public void Run(string userInput)
        {
            try
            {
                PrepareFast();

                if (program.errors.Count > 0)
                {
                    return;
                }

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
                            //view.Refresh();
                            console.Refresh();
                        }

                        if (program.program[currentCommand].Type() == new TRAP().Type())
                        {
                            this.isTrapped = true;
                            this.isDegugging = true;
                            VisualizeCommand();
                            VisualizeStack();
                            console.Text += "Program was trapped\n";
                            //MessageBox.Show("trap");
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
                                    executedCommands[i].count = executedCommands[i].count + 1;
                                }
                            }
                            perfomance.Add(currentCommand);
                            program.program[currentCommand].Execute(this);
                        }
                        catch (InvalidOperationException e)
                        {
                            message = "The exceptional situation was occured on the line ";
                            message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += "the stack is empty";
                            console.Text += "\n" + message;
                            ShutDown();
                            return;
                        }
                        catch (DivideByZeroException e)
                        {
                            message = currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += "dividing by zero";
                            console.Text += "\n" + message;
                            ShutDown();
                            return;
                        }
                        catch (ArgumentException e)
                        {
                            message = currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += "invalid argument";
                            console.Text += "\n" + message;
                            ShutDown();
                            return;
                        }
                        catch (Lib.Exceptions.NoSuchLabelException e)
                        {
                            message = currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += "there are not such label";
                            console.Text += "\n" + message;
                            ShutDown();
                            return;
                        }
                        catch (Exception e)
                        {
                            message = currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += currentCommand + " : " + "\"" + box.Text.Split('\n')[currentCommand] + "\" because of ";
                            message += "some sort of magic";
                            console.Text += "\n" + message;
                            ShutDown();
                            return;
                        }


                        currentCommand++;

                        //VisualizeCommand();
                        //view.Refresh();

                        if (fastMode == false)
                        {
                            box.SelectionStart = 0;
                            box.SelectionLength = box.Text.Length;
                            box.SelectionBackColor = Color.White;
                            box.Refresh();
                        }
                    }
                    else
                    {

                        console.Text += "\nTerminated\n";
                        isExecuting = false;
                        PerfomanceReport();
                        console.Refresh();

                        VisualizeCommand();
                        VisualizeStack();
                        view.Refresh();
                        console.Refresh();
                        program.program[currentCommand].Execute(this);
                        box.Refresh();
                        thread.Abort();
                        //thread = new Thread(BeginProcess);
                        isDegugging = false;
                        box.Refresh();

                        break;
                    }
                }
            }
            catch (Exception e13)
            {
                message = "The exceptional situation was occured because of ";
                message += "some sort of magic";
                console.Text += message;
                try 
                {
                    ShutDown();
                }
                catch(Exception e14)
                {
                    this.isExecuting = false;
                }
                return;
            }
        }
        #endregion



        #region
        public void ClearMemory()
        {
            for (int i = 0; i < Memory.MEMORY_SIZE; i++)
            {
                memory[i] = new OctoByte();
            }

            for (int i = 0; i < Memory.REGISTERS_NUMBER; i++)
            {
                memory.SetRegister(i, new OctoByte());
            }
        }
        #endregion

        #region
        public void PerfomanceReport()
        {
            if (perfomanceAnalize)
            {
                int summ = 0;
                for (int i = 0; i < executedCommands.Count; i++)
                {
                    summ += executedCommands[i].count;
                }

                console.Text += "Total executed: " + summ + "\n";

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
                        console.Text += executedCommands[i].type.PadLeft(10) + "   -  " + (executedCommands[i].count + "").PadLeft(7) + "\n";
                    }
                }
                List<double> lines = perfomance.GetLines();
                for (int i = 0; i < lines.Count; i++)
                {
                    int brighttness = 255 - (int)((lines[i] * 255) / 1.5);
                    ShowLine(i, Color.FromArgb(brighttness, brighttness, 255));
                }
            }
        }
        #endregion

        #region
        public void ShutDown()
        {
            message = "";
            //ClearMemory();
            VisualizeCommand();
            VisualizeStack();
            //stackView.Refresh();
            view.Refresh();
            console.Refresh();
            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
            box.SelectionBackColor = Color.White;
            //currentCommand = 0;
            //HightLight(box);
            box.Refresh();
            isDegugging = false;
            isExecuting = false;
            box.Enabled = true;
            //box.Enabled = true;
        }
        #endregion

        #region
        public void PrepareConsole()
        {
            if (input.Visible)
            {
                input.ShowDialog();
            }
            else
            {
                input.Visible = true;
            }
        }
        #endregion

        #region
        public void VisualizeStack()
        {
            stackView.Items.Clear();
            for (int i = 0; i < stack.Count; i++)
            {
                stackView.Items.Add(stack.ElementAt<string>(i));
            }
            stackView.Refresh();
        }
        #endregion

        public void selectAddress(bool isRegister, int address)
        {
            if (isRegister)
            {
                selectedRegisters.Add(address);
            }
            else
            {
                selectedOctos.Add(address);
            }
        }

        public void deselectAll()
        {
            selectedRegisters.Clear();
            selectedOctos.Clear();
        }

        public void VisualizeCommand()
        {
            ShowLine(currentCommand, Color.FromArgb(200, 255, 255));
            view.Refresh();
        }

        #region
        public void ShowLine(int line, Color color)
        {
            int begin = program.linesBeginEnd[line].begin;
            int end = program.linesBeginEnd[line].end;
            box.SelectionStart = begin;
            box.SelectionLength = end - begin;
            box.SelectionBackColor = color;
            box.ShowSelectionMargin = true;
            box.Refresh();
        }
        #endregion

        #region
        public void HightLight(RichTextBox box)
        {

            
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
        #endregion
    }
}
