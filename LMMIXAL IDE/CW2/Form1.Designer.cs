namespace CW
{
    partial class Assembler
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.code = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.RichTextBox();
            this.stack = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMacrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hightlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dehightlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepDurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veryShort30MsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.short70MsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medium300MsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.long900MsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veryLong3000MsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfomanceAnalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.db = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.commandsBox = new System.Windows.Forms.ListBox();
            this.hint = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.AutoWordSelection = true;
            this.code.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.code.DetectUrls = false;
            this.code.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.code.Location = new System.Drawing.Point(12, 72);
            this.code.Name = "code";
            this.code.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.code.ShowSelectionMargin = true;
            this.code.Size = new System.Drawing.Size(339, 511);
            this.code.TabIndex = 1;
            this.code.Text = "";
            this.code.VScroll += new System.EventHandler(this.code_VScroll);
            this.code.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            this.code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            this.code.MouseMove += new System.Windows.Forms.MouseEventHandler(this.code_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.console.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.console.Location = new System.Drawing.Point(357, 439);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(293, 142);
            this.console.TabIndex = 3;
            this.console.Text = "";
            this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
            this.console.KeyDown += new System.Windows.Forms.KeyEventHandler(this.console_KeyDown);
            this.console.KeyUp += new System.Windows.Forms.KeyEventHandler(this.console_KeyUp);
            // 
            // stack
            // 
            this.stack.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.stack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stack.FormattingEnabled = true;
            this.stack.Location = new System.Drawing.Point(656, 136);
            this.stack.Name = "stack";
            this.stack.Size = new System.Drawing.Size(143, 160);
            this.stack.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importMacrosToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.файлToolStripMenuItem.Text = "File";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.новыйToolStripMenuItem.Text = "New";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.загрузитьToolStripMenuItem.Text = "Load";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importMacrosToolStripMenuItem
            // 
            this.importMacrosToolStripMenuItem.Name = "importMacrosToolStripMenuItem";
            this.importMacrosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.importMacrosToolStripMenuItem.Text = "Execute substitution";
            this.importMacrosToolStripMenuItem.Click += new System.EventHandler(this.importMacrosToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hightlightToolStripMenuItem,
            this.dehightlightToolStripMenuItem,
            this.clearMemoryToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // hightlightToolStripMenuItem
            // 
            this.hightlightToolStripMenuItem.Name = "hightlightToolStripMenuItem";
            this.hightlightToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.hightlightToolStripMenuItem.Text = "Reset perfomance report";
            this.hightlightToolStripMenuItem.Click += new System.EventHandler(this.hightlightToolStripMenuItem_Click);
            // 
            // dehightlightToolStripMenuItem
            // 
            this.dehightlightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.dehightlightToolStripMenuItem.Name = "dehightlightToolStripMenuItem";
            this.dehightlightToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.dehightlightToolStripMenuItem.Text = "Set register";
            this.dehightlightToolStripMenuItem.Click += new System.EventHandler(this.dehightlightToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "0";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "1";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "2";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem5.Text = "3";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem6.Text = "4";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem7.Text = "5";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem8.Text = "6";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem9.Text = "7";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // clearMemoryToolStripMenuItem
            // 
            this.clearMemoryToolStripMenuItem.Name = "clearMemoryToolStripMenuItem";
            this.clearMemoryToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.clearMemoryToolStripMenuItem.Text = "Clear memory";
            this.clearMemoryToolStripMenuItem.Click += new System.EventHandler(this.clearMemoryToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryModeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // memoryModeToolStripMenuItem
            // 
            this.memoryModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicalToolStripMenuItem,
            this.hexToolStripMenuItem});
            this.memoryModeToolStripMenuItem.Name = "memoryModeToolStripMenuItem";
            this.memoryModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.memoryModeToolStripMenuItem.Text = "Memory mode";
            // 
            // graphicalToolStripMenuItem
            // 
            this.graphicalToolStripMenuItem.Name = "graphicalToolStripMenuItem";
            this.graphicalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.graphicalToolStripMenuItem.Text = "Graphical";
            this.graphicalToolStripMenuItem.Click += new System.EventHandler(this.graphicalToolStripMenuItem_Click);
            // 
            // hexToolStripMenuItem
            // 
            this.hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            this.hexToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.hexToolStripMenuItem.Text = "Hex";
            this.hexToolStripMenuItem.Click += new System.EventHandler(this.hexToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchModeToolStripMenuItem,
            this.beepDurationToolStripMenuItem,
            this.beepsToolStripMenuItem,
            this.perfomanceAnalizeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // launchModeToolStripMenuItem
            // 
            this.launchModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastToolStripMenuItem,
            this.slowToolStripMenuItem});
            this.launchModeToolStripMenuItem.Name = "launchModeToolStripMenuItem";
            this.launchModeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.launchModeToolStripMenuItem.Text = "Launch mode";
            this.launchModeToolStripMenuItem.Click += new System.EventHandler(this.launchModeToolStripMenuItem_Click);
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.fastToolStripMenuItem.Text = "Fast";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.fastToolStripMenuItem_Click);
            // 
            // slowToolStripMenuItem
            // 
            this.slowToolStripMenuItem.Name = "slowToolStripMenuItem";
            this.slowToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.slowToolStripMenuItem.Text = "Slow";
            this.slowToolStripMenuItem.Click += new System.EventHandler(this.slowToolStripMenuItem_Click);
            // 
            // beepDurationToolStripMenuItem
            // 
            this.beepDurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veryShort30MsToolStripMenuItem,
            this.short70MsToolStripMenuItem,
            this.medium300MsToolStripMenuItem,
            this.long900MsToolStripMenuItem,
            this.veryLong3000MsToolStripMenuItem});
            this.beepDurationToolStripMenuItem.Name = "beepDurationToolStripMenuItem";
            this.beepDurationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.beepDurationToolStripMenuItem.Text = "Beep duration";
            // 
            // veryShort30MsToolStripMenuItem
            // 
            this.veryShort30MsToolStripMenuItem.Name = "veryShort30MsToolStripMenuItem";
            this.veryShort30MsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.veryShort30MsToolStripMenuItem.Text = "Very short (30 ms)";
            this.veryShort30MsToolStripMenuItem.Click += new System.EventHandler(this.veryShort30MsToolStripMenuItem_Click);
            // 
            // short70MsToolStripMenuItem
            // 
            this.short70MsToolStripMenuItem.Name = "short70MsToolStripMenuItem";
            this.short70MsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.short70MsToolStripMenuItem.Text = "Short (70 ms)";
            this.short70MsToolStripMenuItem.Click += new System.EventHandler(this.short70MsToolStripMenuItem_Click);
            // 
            // medium300MsToolStripMenuItem
            // 
            this.medium300MsToolStripMenuItem.Name = "medium300MsToolStripMenuItem";
            this.medium300MsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.medium300MsToolStripMenuItem.Text = "Medium (300 ms)";
            this.medium300MsToolStripMenuItem.Click += new System.EventHandler(this.medium300MsToolStripMenuItem_Click);
            // 
            // long900MsToolStripMenuItem
            // 
            this.long900MsToolStripMenuItem.Name = "long900MsToolStripMenuItem";
            this.long900MsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.long900MsToolStripMenuItem.Text = "Long (900 ms)";
            this.long900MsToolStripMenuItem.Click += new System.EventHandler(this.long900MsToolStripMenuItem_Click);
            // 
            // veryLong3000MsToolStripMenuItem
            // 
            this.veryLong3000MsToolStripMenuItem.Name = "veryLong3000MsToolStripMenuItem";
            this.veryLong3000MsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.veryLong3000MsToolStripMenuItem.Text = "Very long (3000 ms)";
            this.veryLong3000MsToolStripMenuItem.Click += new System.EventHandler(this.veryLong3000MsToolStripMenuItem_Click);
            // 
            // beepsToolStripMenuItem
            // 
            this.beepsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onToolStripMenuItem,
            this.offToolStripMenuItem});
            this.beepsToolStripMenuItem.Name = "beepsToolStripMenuItem";
            this.beepsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.beepsToolStripMenuItem.Text = "Beeps";
            // 
            // onToolStripMenuItem
            // 
            this.onToolStripMenuItem.Name = "onToolStripMenuItem";
            this.onToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.onToolStripMenuItem.Text = "On";
            this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
            // 
            // offToolStripMenuItem
            // 
            this.offToolStripMenuItem.Name = "offToolStripMenuItem";
            this.offToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.offToolStripMenuItem.Text = "Off";
            this.offToolStripMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // perfomanceAnalizeToolStripMenuItem
            // 
            this.perfomanceAnalizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onToolStripMenuItem1,
            this.offToolStripMenuItem1});
            this.perfomanceAnalizeToolStripMenuItem.Name = "perfomanceAnalizeToolStripMenuItem";
            this.perfomanceAnalizeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.perfomanceAnalizeToolStripMenuItem.Text = "Perfomance Analize";
            // 
            // onToolStripMenuItem1
            // 
            this.onToolStripMenuItem1.Name = "onToolStripMenuItem1";
            this.onToolStripMenuItem1.Size = new System.Drawing.Size(90, 22);
            this.onToolStripMenuItem1.Text = "On";
            this.onToolStripMenuItem1.Click += new System.EventHandler(this.onToolStripMenuItem1_Click);
            // 
            // offToolStripMenuItem1
            // 
            this.offToolStripMenuItem1.Name = "offToolStripMenuItem1";
            this.offToolStripMenuItem1.Size = new System.Drawing.Size(90, 22);
            this.offToolStripMenuItem1.Text = "Off";
            this.offToolStripMenuItem1.Click += new System.EventHandler(this.offToolStripMenuItem1_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // open
            // 
            this.open.FileName = "openFileDialog1";
            // 
            // db
            // 
            this.db.Location = new System.Drawing.Point(181, 27);
            this.db.Name = "db";
            this.db.Size = new System.Drawing.Size(170, 39);
            this.db.TabIndex = 8;
            this.db.Text = "Continue";
            this.db.UseVisualStyleBackColor = true;
            this.db.Click += new System.EventHandler(this.db_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(690, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Stack";
            // 
            // commandsBox
            // 
            this.commandsBox.FormattingEnabled = true;
            this.commandsBox.Location = new System.Drawing.Point(656, 343);
            this.commandsBox.Name = "commandsBox";
            this.commandsBox.Size = new System.Drawing.Size(143, 238);
            this.commandsBox.TabIndex = 10;
            this.commandsBox.SelectedIndexChanged += new System.EventHandler(this.commandsBox_SelectedIndexChanged);
            this.commandsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.commandsBox_MouseDoubleClick);
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hint.Location = new System.Drawing.Point(16, 586);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(0, 18);
            this.hint.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(653, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Instruction set";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(656, 58);
            this.trackBar1.Maximum = 3000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(143, 42);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(651, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Program speed";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(273, 4250);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox3_Paint);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Assembler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(817, 603);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hint);
            this.Controls.Add(this.commandsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.db);
            this.Controls.Add(this.stack);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.console);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.code);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Assembler";
            this.Text = "MMIX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox code;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ListBox stack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog save;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.Button db;
        private System.Windows.Forms.ToolStripMenuItem hightlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dehightlightToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem launchModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beepDurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veryShort30MsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem short70MsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medium300MsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem long900MsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veryLong3000MsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
        private System.Windows.Forms.ListBox commandsBox;
        private System.Windows.Forms.Label hint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem clearMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfomanceAnalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importMacrosToolStripMenuItem;
    }
}

