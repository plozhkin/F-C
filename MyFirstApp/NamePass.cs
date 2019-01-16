using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class NamePass : Form
    {
        public bool cancel = false;
        public NamePass()
        {
            InitializeComponent();
        }
        public string GetName()
        {
            return this.textBox1.Text;
        }
        public string GetPass()
        {
            return this.textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.cancel = true;
            this.Close();

        }

        private void NamePass_Load(object sender, EventArgs e)
        {
            this.textBox1.Select();
        }
    }
}
