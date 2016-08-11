namespace AttendanceTools
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.BtnImport = new MetroFramework.Controls.MetroButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExport = new MetroFramework.Controls.MetroButton();
            this.tbFileName = new MetroFramework.Controls.MetroTextBox();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.dataGridView1 = new MetroFramework.Controls.MetroGrid();
            this.lblweek = new MetroFramework.Controls.MetroLink();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(20, 99);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(140, 30);
            this.BtnImport.TabIndex = 1;
            this.BtnImport.Text = "导入考勤表格";
            this.BtnImport.UseSelectable = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.菜单ToolStripMenuItem.Text = "节假日设置";
            this.菜单ToolStripMenuItem.Click += new System.EventHandler(this.菜单ToolStripMenuItem_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(485, 99);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(140, 30);
            this.BtnExport.TabIndex = 9;
            this.BtnExport.Text = "导出数据";
            this.BtnExport.UseSelectable = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Lines = new string[0];
            this.tbFileName.Location = new System.Drawing.Point(251, 99);
            this.tbFileName.Margin = new System.Windows.Forms.Padding(0);
            this.tbFileName.MaxLength = 32767;
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.PasswordChar = '\0';
            this.tbFileName.PromptText = "导出的文件名";
            this.tbFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFileName.SelectedText = "";
            this.tbFileName.Size = new System.Drawing.Size(143, 30);
            this.tbFileName.TabIndex = 11;
            this.tbFileName.UseSelectable = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 408);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(606, 24);
            this.progressBar1.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(23, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(603, 232);
            this.dataGridView1.TabIndex = 16;
            // 
            // lblweek
            // 
            this.lblweek.BackColor = System.Drawing.Color.Gainsboro;
            this.lblweek.Location = new System.Drawing.Point(20, 141);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(606, 23);
            this.lblweek.TabIndex = 17;
            this.lblweek.Text = "默认为周六周日";
            this.lblweek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblweek.UseCustomBackColor = true;
            this.lblweek.UseSelectable = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 431);
            this.Controls.Add(this.lblweek);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BtnImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "考勤";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private MetroFramework.Controls.MetroButton BtnImport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private MetroFramework.Controls.MetroButton BtnExport;
        private MetroFramework.Controls.MetroTextBox tbFileName;
        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private MetroFramework.Controls.MetroGrid dataGridView1;
        private MetroFramework.Controls.MetroLink lblweek;




    }
}