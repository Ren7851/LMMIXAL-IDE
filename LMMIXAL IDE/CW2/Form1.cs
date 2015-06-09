using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Computer;
using Lib.Computer.Commands;
using Lib.Utils;
using Lib.Computer.MakeProgram;
using CW.View;
using System.Diagnostics;

using Lib.Computer.Commands.ByteArithmeticCommands;
using Lib.Computer.Commands.ConsolelCommands;
using Lib.Computer.Commands.GOTO;
using Lib.Computer.Commands.If;
using Lib.Computer.Commands.LongArithmeticCommands;
using Lib.Computer.Commands.OctoBoolCommands;
using Lib.Computer.Commands.If.ExpressionsParsing;
using Lib.Computer.Commands.If.ConditionActions;
using System.Runtime.InteropServices;

namespace CW
{
    public partial class Assembler : Form
    {
        public CW2.UserInput userInput;
        public Computer computer;
        public static string FILE_EXCENTION = "ball";
        public static List<Command> list = new List<Command>();
        Expression expression = new Expression("not(0 eqv 1) eqv 1");
        public string input = "";
        public CW2.SetRegister setRegisterForm;


        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        //для удобства использования создаем перечисление с необходимыми флагами (константами), которые определяют действия мыши: 
        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
            RightUp = 0x0010, Absolute = 0x8000
        };



        public Assembler()
        {
            InitializeComponent();
            userInput = new CW2.UserInput(this);
        }

        public void SetRegister(string value, int index)
        {
            value = new string('0', OctoByte.OCTO_SIZE * Lib.Computer.Byte.BYTE_SIZE / 4 - value.Length) + value;
            computer.memory.SetRegister(index, new OctoByte(value));
            this.pictureBox3.Refresh();
        }

        private void Test()
        {
            DateTime now = DateTime.Now;
            OctoByte octo = new OctoByte("0000000000000011");
            long time = now.Ticks / 10000;
            Expression expression = new Expression("( 5 + 9 ) / ( 7 - 9 ) * 8 + 9");
            for (int i = 0; i < 1000000; i++)
            {
                expression.Calculate();
            }
            now = DateTime.Now;
            long newTime = now.Ticks / 10000;
            MessageBox.Show((newTime - time) + "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Test();
            list.Add(new BADD("", ""));
            list.Add(new BDIV("", ""));
            list.Add(new BMOD("", ""));
            list.Add(new BMULT("", ""));
            list.Add(new BPOW("", ""));
            list.Add(new BSUB("", ""));
            list.Add(new INB(""));
            list.Add(new IND(""));
            list.Add(new INH(""));
            list.Add(new INL(""));
            list.Add(new OUTB(""));
            list.Add(new OUTD(""));
            list.Add(new OUTH(""));
            list.Add(new OUTL(""));
            list.Add(new WRITE(""));
            list.Add(new DADD("", ""));
            list.Add(new DDIV("", ""));
            list.Add(new DMOD("", ""));
            list.Add(new DMULT("", ""));
            list.Add(new DPOW("", ""));
            list.Add(new DSUB("", ""));
            list.Add(new DSQRT("", ""));
            list.Add(new DLOG("", ""));
            list.Add(new GOTO(""));
            list.Add(new GOTONEG("", ""));
            list.Add(new GOTOPOS("", ""));
            list.Add(new GOTOZERO("", ""));
            list.Add(new LABEL(""));
            list.Add(new BEQUAL("", "", ""));
            list.Add(new BLESS("", "", ""));
            list.Add(new BMORE("", "", ""));
            list.Add(new DEQUAL("", "", ""));
            list.Add(new DLESS("", "", ""));
            list.Add(new DMORE("", "", ""));
            list.Add(new LEQUAL("", "", ""));
            list.Add(new LLESS("", "", ""));
            list.Add(new LMORE("", "", ""));
            list.Add(new ENDIF());
            list.Add(new IF(""));
            list.Add(new LADD("", ""));
            list.Add(new LDIV("", ""));
            list.Add(new LMOD("", ""));
            list.Add(new LMULT("", ""));
            list.Add(new LPOW("", ""));
            list.Add(new LSUB("", ""));

            list.Add(new ANDO("", ""));
            list.Add(new EQVO("", ""));
            list.Add(new NANDO("", ""));
            list.Add(new NORO("", ""));
            list.Add(new NOT(""));
            list.Add(new ORO("", ""));

            list.Add(new SHR("", ""));
            list.Add(new SHL("", ""));
            list.Add(new XORO("", ""));

            list.Add(new CALL("", new string[1]));
            list.Add(new CLRMEMORY());
            list.Add(new DEC(""));
            list.Add(new DTOL(""));
            list.Add(new HALT());
            list.Add(new IN("", ""));
            list.Add(new INC(""));
            list.Add(new IS("", ""));
            list.Add(new LTOD(""));
            list.Add(new MOV("", ""));
            list.Add(new PAUSE(""));
            list.Add(new POP());
            list.Add(new PUSH(""));

            list.Add(new RANDOMB("", "", ""));
            list.Add(new RANDOML("", "", ""));
            list.Add(new RANDOMD(""));

            list.Add(new RET());
            list.Add(new ROUND("", ""));
            list.Add(new SUB(""));
            list.Add(new TRAP());
            list.Add(new CEIL(""));
            list.Add(new FLOOR(""));
            list.Add(new WRITELN(""));
            list.Add(new EXPR("", ""));



            list.Add(new CSEV("", "", ""));
            list.Add(new CSN("", "", ""));
            list.Add(new CSNN("", "", ""));
            list.Add(new CSNP("", "", ""));
            list.Add(new CSNZ("", "", ""));
            list.Add(new CSOD("", "", ""));
            list.Add(new CSP("", "", ""));
            list.Add(new CSZ("", "", ""));

            list.Add(new ZSEV("", "", ""));
            list.Add(new ZSN("", "", ""));
            list.Add(new ZSNN("", "", ""));
            list.Add(new ZSNP("", "", ""));
            list.Add(new ZSNZ("", "", ""));
            list.Add(new ZSOD("", "", ""));
            list.Add(new ZSP("", "", ""));
            list.Add(new ZSZ("", "", ""));

            list.Add(new CMP("", "", ""));
            list.Add(new LDIF("", ""));
            list.Add(new BDIF("", ""));
            list.Add(new MOR("", "", ""));
            list.Add(new MXOR("", "", ""));
            list.Add(new GO(""));
            list.Add(new JUMP(""));
            list.Add(new Lib.Computer.Commands.DoubleArithmeticCommands.DDIF("", ""));

            list.Sort();

            string[] names = new string[list.Count];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = list[i].Type();
            }
            Computer.keywords = names;

            for (int i = 0; i < list.Count; i++)
            {
                this.commandsBox.Items.Add(list[i].Type());
            }


            Memory memory = new Memory();

            computer = new Computer(memory, this.code, this.pictureBox3, this.console, this.stack, userInput);

            Panel panel1 = new Panel();
            panel1.AutoScroll = true;
            panel1.Controls.Add(this.pictureBox3);
            panel1.Location = new System.Drawing.Point(360, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(290, 400);
            panel1.TabIndex = 8;
            this.Controls.Add(panel1);
            this.trackBar1.Value = (int)Lib.Computer.Scale.PositionByValue(computer.beepDuration);

        }

        public double f(double a)
        {
            if (a == 1 || a == 0)
            {
                return 1;
            }
            else
            {
                return f(a - 1) * a;
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            View.View.ViewMemory(computer, e);
            //View.ViewSettings.style = View.ViewStyle.hexNumbers;

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(code.Text == "")
            {
                MessageBox.Show("Source is empty");
                return;
            }
            try
            {
                timer1.Enabled = false;
                Lib.Computer.Program program = Lib.Computer.MakeProgram.ProgramMaker.Make(this.code.Text, computer);
                computer.program = program;
                if (computer.fastMode)
                {
                    timer1.Enabled = false;
                    computer.Launch();
                }
                else
                {
                    //this.code.Enabled = false;
                    //computer.IsErrorMessageShowed = false;
                    timer1.Enabled = false;
                    computer.MakeLaunch();
                    //MessageBox.Show(computer.isExecuting + "");R
                    timer1.Enabled = true;
                    computer.beepDuration = timer1.Interval;
                    pictureBox3.Refresh();
                }
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }


        void EmergencySituation()
        {
            MessageBox.Show("Emergency situation was occured. You can save changes");
            SaveProject();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //computer.HightLight(this.richTextBox1);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                View.View.ViewMemory(computer, e);
            }
            catch(Exception e6)
            {
                EmergencySituation();
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //computer.HightLight(this.richTextBox1);
        }

        private void console_KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void Continue(string input)
        {
            try
            {
                if (computer.fastMode)
                {
                    computer.Run(input);
                }
                else
                {
                    this.input = input;
                    computer.isExecuting = true;
                }

            }
            catch (Exception e)
            {
                EmergencySituation();
            }
            //computer.currentCommand++;
            //this.userInput.Hide();
        }

        private void console_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Save project?", "Save", MessageBoxButtons.YesNo);
            this.code.Text = "";
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProject();
                code.SelectionStart = 0;
                code.SelectionLength = code.Text.Length;
                code.SelectionBackColor = Color.White;
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProject();
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        public void SaveProject()
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                string[] lines = code.Lines;

                if (save.FileName.IndexOf(".") == -1)
                {
                    System.IO.File.WriteAllLines(save.FileName + "." + FILE_EXCENTION, lines);
                }
                else
                {
                    System.IO.File.WriteAllLines(save.FileName, lines);
                }
            }
        }


        public void LoadProject()
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                code.Lines = System.IO.File.ReadAllLines(open.FileName);
            }
        }

        private void stepByStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                computer.Resume();
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        private void stepByStepToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveTraps();
                string text = Lib.Computer.MakeProgram.ProgramMaker.InsertTraps(this.code.Text);
                code.Text = text;
                Lib.Computer.Program program = Lib.Computer.MakeProgram.ProgramMaker.Make(text, computer);

                computer.program = program;
                computer.Launch();
                pictureBox3.Refresh();
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        private void insertTrapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Lib.Computer.MakeProgram.ProgramMaker.InsertTraps(this.code.Text);
                code.Text = text;
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        public void RemoveTraps()
        {
            string text = "";
            string[] array = code.Lines;
            List<string> list = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].IndexOf("TRAP") == -1)
                {
                    list.Add(array[i]);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    text += list[i];
                    break;
                }
                text += list[i] + "\n";
            }

            code.Text = text;

        }

        private void debug_Click(object sender, EventArgs e)
        {
            /*
            if (code.Lines[code.Lines.Length - 1].Length == 0)
            {
                code.Text = code.Text.Substring(0, code.Text.Length - 1);
            }
             * */

            try
            {
                RemoveTraps();
                string text = Lib.Computer.MakeProgram.ProgramMaker.InsertTraps(this.code.Text);
                code.Text = text;
                Lib.Computer.Program program = Lib.Computer.MakeProgram.ProgramMaker.Make(text, computer);

                computer.program = program;
                computer.Launch();
                pictureBox3.Refresh();
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        private void db_Click(object sender, EventArgs e)
        {
            try
            {
                if (!computer.isDegugging)
                {
                    /*
                    computer.isDegugging = true;
                    if (code.Lines[code.Lines.Length - 1].Length == 0)
                    {
                        code.Text = code.Text.Substring(0, code.Text.Length - 1);
                    }

                    RemoveTraps();
                    string text = Lib.Computer.MakeProgram.ProgramMaker.InsertTraps(this.code.Text);
                    code.Text = text;
                    Lib.Computer.Program program = Lib.Computer.MakeProgram.ProgramMaker.Make(text);

                    computer.program = program;
                    computer.Launch();
                    pictureBox3.Refresh();
                     * */
                }
                else
                {
                    //computer.isExecuting = true;
                    try
                    {
                        if (computer.fastMode)
                        {
                            computer.Resume();
                        }
                        else
                        {
                            computer.MakeResume();
                        }
                    }
                    catch (Exception en) { EmergencySituation(); }
                }
            }
            catch (Exception em)
            {
                EmergencySituation();
            }
        }

        private void hightlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code.SelectionStart = 0;
            code.SelectionLength = code.Text.Length;
            code.SelectionBackColor = Color.White;
            //computer.HightLight(code);
        }

        private void dehightlightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void console_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //console.Text = console.Text.Substring(console.Text.Length - 1);
            }
        }

        private void graphicalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.ViewSettings.style = ViewStyle.hexColor;
            computer.view.Refresh();
        }

        private void hexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.ViewSettings.style = ViewStyle.hexNumbers;
            computer.view.Refresh();
        }

        private void launchModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void veryShort30MsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.beepDuration = 30;
            this.trackBar1.Value = (int)Lib.Computer.Scale.PositionByValue(computer.beepDuration);
        }

        private void short70MsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.beepDuration = 70;
            this.trackBar1.Value = (int)Lib.Computer.Scale.PositionByValue(computer.beepDuration);
        }

        private void medium300MsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.beepDuration = 300;
            this.trackBar1.Value = (int)Lib.Computer.Scale.PositionByValue(computer.beepDuration);
        }

        private void long900MsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.beepDuration = 900;
            this.trackBar1.Value = (int)Lib.Computer.Scale.PositionByValue(computer.beepDuration);
        }

        private void veryLong3000MsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.beepDuration = 3000;
            this.trackBar1.Value = (int)Lib.Computer.Scale.PositionByValue(computer.beepDuration);
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.fastMode = true;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.fastMode = false;
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.isBeeps = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.isBeeps = false;
        }

        private void commandsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            hint.Text = list[this.commandsBox.SelectedIndex].Syntax.PadRight(45) + list[this.commandsBox.SelectedIndex].Description;
        }

        private void commandsBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            code.Text += list[this.commandsBox.SelectedIndex].Syntax + "\n";
        }


        private void code_VScroll(object sender, EventArgs e)
        {
            //int vPos = GetScrollPos(code.Handle, SB_VERT);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (computer.isExecuting)
                {
                    //code.Enabled = false;
                    computer.Next(input);
                    if (input != "")
                    {
                        input = "";
                    }
                }
            }
            catch(Exception e13)
            {
                EmergencySituation();
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (this.trackBar1.Value > 0)
            {
                this.timer1.Interval = (int)Lib.Computer.Scale.ValueByPosition(this.trackBar1.Value);
                computer.beepDuration = (int)Lib.Computer.Scale.ValueByPosition(this.trackBar1.Value);
            }
        }

        private void clearMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer.ClearMemory();
            computer.view.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 0);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 1);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 2);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 3);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 4);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 5);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 6);
            setRegisterForm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            setRegisterForm = new CW2.SetRegister(this, 7);
            setRegisterForm.Show();
        }

        private void monkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //timer2.Start();
        }

        int count = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                int x = 5000 + random.Next(38000);
                int y = random.Next(60000);
                mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
                mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
                mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
            }
            else
            {
                SendKeys.Send((char)random.Next('A', 'Z') + "");
            }
            count++;

            if (count == 1000)
            {
                timer2.Stop();
                count = 0;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            computer.isExecuting = false;
        }

        private void onToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            computer.perfomanceAnalize = true;
        }

        private void offToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            computer.perfomanceAnalize = false;
        }

        private void code_MouseMove(object sender, MouseEventArgs e)
        {
            if (computer.isExecuting)
            {
                int x = 30000;
                int y = 30000;
                mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            }
        }

        private void importMacrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Macros.GetInstance().Set(save.FileName);
                        string text = this.code.Text;
                        this.code.Text = Macros.GetInstance().Substitute(text);
                    }
                    catch(Exception q)
                    {
                    
                    }
                }
            }
            catch(Exception e6)
            {
                EmergencySituation();
            }
        }

        private void executeMacrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
