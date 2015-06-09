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
    public partial class SetRegister : Form
    {
        private CW.Assembler host;
        private int index;
        public SetRegister(CW.Assembler host, int index)
        {
            InitializeComponent();
            this.host = host;
            this.index = index;
        }

        private void SetRegister_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                host.SetRegister(this.textBox1.Text, index);
                this.Hide();
            }
            catch(Exception e3)
            {
                MessageBox.Show("Invalid input");
            }
        }
    }
}
