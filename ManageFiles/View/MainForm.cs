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

namespace ManageFiles.View
{
    public partial class MainForm : Form
    {
        public FileController fc;
        public MainForm()
        {
            InitializeComponent();
            fc = null;
        }

        public void updatePath()
        {
            if (fc != null) this.label1.Text = fc.getCurrentDir().getAdd();
        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            if (fc == null)
            {
                WarnForm wff = new WarnForm("无文件信息，请先创建/读取文件");
                wff.ShowDialog();
                return;
            }
            CreateFile ft = new CreateFile();
            ft.ShowDialog();
            resetGrid();
        }

        private void CreateTheFileButton_Click(object sender, EventArgs e)
        {
            CreateTheFile ctf = new CreateTheFile();
            ctf.ShowDialog();
            updatePath();
            resetGrid();
            if (fc != null)
                this.Text = "文件管理系统:" + fc.getFileName();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (fc == null)
            {
                WarnForm wff = new WarnForm("无文件信息，请先创建/读取文件");
                wff.ShowDialog();
                return;
            }
            fc.save();
            WarnForm wf = new WarnForm("保存成功");
            wf.ShowDialog();
        }

        private void RecreateButton_Click(object sender, EventArgs e)
        {
            if (fc == null)
            {
                WarnForm wff = new WarnForm("无文件信息，请先创建/读取文件");
                wff.ShowDialog();
                return;
            }
            fc = new FileController(fc.getFileName(), false);
            resetGrid();
        }

        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            CreateTheFile ctf = new CreateTheFile();
            ctf.ShowDialog();
        }

        public void resetGrid()
        {
            dataGridView1.Rows.Clear();
            if (fc == null)
                return;
            foreach (int i in fc.getCurrentDir().getChildren())
            {
                FCB fcb = fc.getFCBs()[i];
                string[] st = { "文件", "目录" };

                int t = dataGridView1.Rows.Add(fcb.getName(), st[Convert.ToInt32(fcb.getType())], fcb.getIndex(), fcb.getLength());
                if (fcb.getType() == Const.DIR)
                    dataGridView1.Rows[t].DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            if (fc == null)
            {
                WarnForm wff = new WarnForm("无文件信息，请先创建/读取文件");
                wff.ShowDialog();
                return;
            }
            List<int> rows;
            rows = new List<int>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (!rows.Contains(cell.RowIndex))
                    rows.Add(cell.RowIndex);
            }
            if (rows.Count <= 0)
            {
                WarnForm wff = new WarnForm("未选行");
                wff.ShowDialog();
                return;
            }
            foreach (int row in rows)
            {
                string name = Convert.ToString(dataGridView1.Rows[row].Cells[0].Value);
                fc.deleteFile(name);
            }
            resetGrid();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if (fc == null)
            {
                WarnForm wff = new WarnForm("无文件信息，请先创建/读取文件");
                wff.ShowDialog();
                return;
            }
            if (fc.getCurrentDir().isRoot())
            {
                WarnForm wff = new WarnForm("已无上一级目录");
                wff.ShowDialog();
                return;
            }
            fc.returnDir();
            updatePath();
            resetGrid();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (fc == null)
            {
                WarnForm wff = new WarnForm("无文件信息，请先创建/读取文件");
                wff.ShowDialog();
                return;
            }
            List<int> rows;
            rows = new List<int>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (!rows.Contains(cell.RowIndex))
                    rows.Add(cell.RowIndex);
            }
            if (rows.Count > 1)
            {
                WarnForm wff = new WarnForm("最多只能选一行");
                wff.ShowDialog();
                return;
            }
            if (rows.Count <= 0)
            {
                WarnForm wff = new WarnForm("未选行");
                wff.ShowDialog();
                return;
            }

            if (Convert.ToString(dataGridView1.Rows[rows[0]].Cells[1].Value) == "目录")
            {
                string name = Convert.ToString(dataGridView1.Rows[rows[0]].Cells[0].Value);
                fc.openDir(name);
                updatePath();
                resetGrid();
            }
            else 
            {
                string name = Convert.ToString(dataGridView1.Rows[rows[0]].Cells[0].Value);
                EditFile ef = new EditFile();
                ef.setBox(fc.readFile(name));
                //索引放在tag里
                foreach(int child in fc.getCurrentDir().getChildren())
                {
                    if (fc.getFCBs()[child].getName() == name)
                        ef.index = child;
                }
                ef.Text += ":"+fc.getCurrentDir().getAdd()+name;
                ef.ShowDialog();
                resetGrid();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
