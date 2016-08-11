using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttendanceTools
{
    public partial class ChooseTimeForm : Form
    {
        public ChooseTimeForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            listBox1.ContextMenuStrip = contextMenuStrip1;
        }

        public string lblName { get; set; }

        public static bool Single = false;

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(dateTimePicker1.Text))
                listBox1.Items.Add(dateTimePicker1.Text);
        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox listbox = contextMenuStrip1.SourceControl as ListBox;//获取contextMenuStrip的关联控件
            int i = listbox.SelectedIndex;
            listbox.Items.Remove(listbox.Items[i]);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var f = (Main)Owner;
            var list = new List<string>();
            foreach (var m in listBox1.Items)
            {
                list.Add(m.ToString());
            }
            if (list.Any())
            {
                (f.Controls[lblName]).Text = string.Join(",", list);
            }
            else
            {
                ((Label)f.Controls[lblName]).Text = "              ";
            }
            this.Close();
        }

        private void ChooseTimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Single = false;
        }

        private void ChooseTimeForm_Load(object sender, EventArgs e)
        {
            Single = true;
        }

    }
}
