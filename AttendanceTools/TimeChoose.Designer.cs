namespace AttendanceTools
{
    partial class TimeChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeChoose));
            this.dateTimePicker1 = new MetroFramework.Controls.MetroDateTime();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.contextMenuStrip1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(2, 63);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 29);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(2, 98);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 196);
            this.listBox1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(235, 63);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "确  定";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.移除ToolStripMenuItem_Click_1);
            // 
            // TimeChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 311);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeChoose";
            this.Text = "节假日选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeChoose_FormClosing);
            this.Load += new System.EventHandler(this.TimeChoose_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dateTimePicker1;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton btnClose;
        private MetroFramework.Controls.MetroContextMenu contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
    }
}