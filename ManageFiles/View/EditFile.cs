using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageFiles.Controller;

namespace ManageFiles.View
{
    public partial class EditFile : Form
    {
        public int index;
        public EditFile()
        {
            InitializeComponent();
        }

        public void setBox(string str)
        {
            textBox1.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileController fc = Program.mf.fc;
            fc.writeFCB(fc.getFCBs()[index],textBox1.Text);
            this.Close();
        }
    }
}
