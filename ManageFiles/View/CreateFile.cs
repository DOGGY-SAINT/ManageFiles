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

namespace ManageFiles.View
{
    public partial class CreateFile : Form
    {
        public CreateFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = this.textBox1.Text;
            if(fileName.Length==0)
            {
                WarnForm wf = new WarnForm("文件名不可为空");
                wf.ShowDialog();
                return;
            }
            if (fileName.Contains('#')|| fileName.Contains('/'))
            {
                WarnForm wf = new WarnForm("文件名不可含#或/");
                wf.ShowDialog();
                return;
            }
            int fileType = this.comboBox1.SelectedIndex;
            foreach (string name in Program.mf.fc.getNames())
                if (fileName == name)
                {
                    WarnForm wf = new WarnForm("文件已存在");
                    wf.ShowDialog();
                    return;
                }
            bool tp = (fileType == 1 ? Const.DIR : Const.FILE);
            Program.mf.fc.newFCB(fileName,tp);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
