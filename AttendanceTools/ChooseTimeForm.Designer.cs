namespace AttendanceTools
{
    partial class ChooseTimeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseTimeForm));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(167, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(204, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(68, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "添加";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 208);
            this.listBox1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.移除ToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(86, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "确定";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChooseTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.dateTimePicker1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseTimeForm";
            this.Text = "选择时间";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseTimeForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseTimeForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
    }
}