namespace AttendanceTools
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加节假日期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblweek = new System.Windows.Forms.Label();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(734, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(1, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 361);
            this.panel1.TabIndex = 1;
            // 
            // BtnImport
            // 
            this.BtnImport.BackColor = System.Drawing.SystemColors.Window;
            this.BtnImport.Location = new System.Drawing.Point(0, 32);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(216, 23);
            this.BtnImport.TabIndex = 2;
            this.BtnImport.Text = "导入考勤表格生成考勤数据";
            this.BtnImport.UseVisualStyleBackColor = false;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.SystemColors.Window;
            this.BtnExport.Location = new System.Drawing.Point(281, 32);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(216, 23);
            this.BtnExport.TabIndex = 3;
            this.BtnExport.Text = "导出数据";
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(527, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "导出文件名：";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(610, 32);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(100, 21);
            this.tbFileName.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 433);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(735, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加节假日期ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 添加节假日期ToolStripMenuItem
            // 
            this.添加节假日期ToolStripMenuItem.Name = "添加节假日期ToolStripMenuItem";
            this.添加节假日期ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加节假日期ToolStripMenuItem.Text = "添加节假日";
            this.添加节假日期ToolStripMenuItem.Click += new System.EventHandler(this.添加节假日期ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "法定节假日：  ";
            // 
            // lblweek
            // 
            this.lblweek.AutoSize = true;
            this.lblweek.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblweek.Location = new System.Drawing.Point(98, 58);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(101, 12);
            this.lblweek.TabIndex = 10;
            this.lblweek.Text = "默认为每周六周日";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(0, 0);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(75, 23);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(735, 458);
            this.Controls.Add(this.lblweek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SabraGirl考勤";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加节假日期ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblweek;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}

