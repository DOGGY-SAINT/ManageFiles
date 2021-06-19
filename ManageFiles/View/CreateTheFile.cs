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
using ManageFiles.Model;
using ManageFiles;
using System.IO;

namespace ManageFiles.View
{
    public partial class CreateTheFile : Form
    {
        public CreateTheFile()
        {
            InitializeComponent();
            this.label3.Text = textBox1.Text + Const.SUFFIX;
            textBox1.TextChanged += new System.EventHandler(this.text_changed);
        }

        private void text_changed(object sender, EventArgs e)
        {
            this.label3.Text = textBox1.Text + Const.SUFFIX;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WarnForm wf;
            if(textBox1.Text=="")
            {
                WarnForm wff = new WarnForm("文件名不可为空");
                wff.ShowDialog();
                return;
            }
            if (File.Exists(label3.Text))
            {
                Program.mf.fc = new FileController(label3.Text, true);
                wf = new WarnForm("文件" + label3.Text + "已存在,读取成功");
            }
            else 
            {
                Program.mf.fc = new FileController(label3.Text, false);
                wf = new WarnForm("文件" + label3.Text + "不存在，创建成功");
            }
            wf.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
