
namespace ManageFiles.View
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateTheFileButton = new System.Windows.Forms.Button();
            this.RecreateButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreateFileButton = new System.Windows.Forms.Button();
            this.DeleteFileButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CreateTheFileButton);
            this.flowLayoutPanel1.Controls.Add(this.RecreateButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Controls.Add(this.CreateFileButton);
            this.flowLayoutPanel1.Controls.Add(this.DeleteFileButton);
            this.flowLayoutPanel1.Controls.Add(this.ReturnButton);
            this.flowLayoutPanel1.Controls.Add(this.OpenButton);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(564, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(224, 426);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // CreateTheFileButton
            // 
            this.CreateTheFileButton.Location = new System.Drawing.Point(3, 3);
            this.CreateTheFileButton.Name = "CreateTheFileButton";
            this.CreateTheFileButton.Size = new System.Drawing.Size(106, 101);
            this.CreateTheFileButton.TabIndex = 2;
            this.CreateTheFileButton.Text = "创建/读取文件";
            this.CreateTheFileButton.UseVisualStyleBackColor = true;
            this.CreateTheFileButton.Click += new System.EventHandler(this.CreateTheFileButton_Click);
            // 
            // RecreateButton
            // 
            this.RecreateButton.Location = new System.Drawing.Point(115, 3);
            this.RecreateButton.Name = "RecreateButton";
            this.RecreateButton.Size = new System.Drawing.Size(106, 101);
            this.RecreateButton.TabIndex = 4;
            this.RecreateButton.Text = "格式化并保存";
            this.RecreateButton.UseVisualStyleBackColor = true;
            this.RecreateButton.Click += new System.EventHandler(this.RecreateButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 110);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(106, 101);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "保存至文件";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateFileButton
            // 
            this.CreateFileButton.Location = new System.Drawing.Point(115, 110);
            this.CreateFileButton.Name = "CreateFileButton";
            this.CreateFileButton.Size = new System.Drawing.Size(106, 101);
            this.CreateFileButton.TabIndex = 0;
            this.CreateFileButton.Text = "创建文件/目录";
            this.CreateFileButton.UseVisualStyleBackColor = true;
            this.CreateFileButton.Click += new System.EventHandler(this.CreateFileButton_Click);
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.Location = new System.Drawing.Point(3, 217);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(106, 101);
            this.DeleteFileButton.TabIndex = 5;
            this.DeleteFileButton.Text = "删除文件/目录";
            this.DeleteFileButton.UseVisualStyleBackColor = true;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(115, 217);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(106, 101);
            this.ReturnButton.TabIndex = 6;
            this.ReturnButton.Text = "返回上一级目录";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(3, 324);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(106, 101);
            this.OpenButton.TabIndex = 7;
            this.OpenButton.Text = "打开目录/文件";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(115, 324);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(106, 101);
            this.button9.TabIndex = 8;
            this.button9.Text = "直接退出";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "请创建为文件";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.fileType,
            this.Index,
            this.Length});
            this.dataGridView1.Location = new System.Drawing.Point(15, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(546, 405);
            this.dataGridView1.TabIndex = 2;
            // 
            // fileName
            // 
            this.fileName.HeaderText = "文件名";
            this.fileName.MinimumWidth = 6;
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // fileType
            // 
            this.fileType.HeaderText = "文件类型";
            this.fileType.MinimumWidth = 6;
            this.fileType.Name = "fileType";
            this.fileType.ReadOnly = true;
            // 
            // Index
            // 
            this.Index.HeaderText = "块起始地址";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.HeaderText = "所占块数";
            this.Length.MinimumWidth = 6;
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前目录:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "文件管理系统";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button CreateFileButton;
        private System.Windows.Forms.Button CreateTheFileButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button RecreateButton;
        private System.Windows.Forms.Button DeleteFileButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.Label label2;
    }
}

