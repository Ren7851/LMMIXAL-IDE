using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW2
{
    public partial class UserInput : Form
    {
        public CW.Assembler host;
        public UserInput(CW.Assembler host)
        {
            InitializeComponent();
            this.host = host;
            this.ControlBox = false;
        }

        private void UserInput_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            host.Continue(this.textBox1.Text);
            this.textBox1.Text = "";
        }

        private void UserInput_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void UserInput_Paint(object sender, PaintEventArgs e)
        {
            //this.textBox1.Text = "";
        }
    }
}
