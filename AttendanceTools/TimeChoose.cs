using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace AttendanceTools
{
    public partial class TimeChoose : MetroForm
    {
        public static TimeChoose CurrentTimeChoose { get; private set; }

        public TimeChoose()
        {

            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            listBox1.ContextMenuStrip = contextMenuStrip1;
            CurrentTimeChoose = this;
        }

        public string lblName { get; set; }

        public static bool Single = false;



        private void btnClose_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            foreach (var m in listBox1.Items)
            {
                list.Add(m.ToString());
            }

            Main.CurrentMain.DateList = list;
            this.Close();
        }


        private void TimeChoose_FormClosing(object sender, FormClosingEventArgs e)
        {
            Single = false;
        }

        private void TimeChoose_Load(object sender, EventArgs e)
        {
            Single = true;
        }

        private void 移除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ListBox listbox = contextMenuStrip1.SourceControl as ListBox;//获取contextMenuStrip的关联控件
            int i = listbox.SelectedIndex;
            listbox.Items.Remove(listbox.Items[i]);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var dt = sender as MetroFramework.Controls.MetroDateTime;
            var val = dt.Value.ToString("yyyy-MM-dd");
            if (!listBox1.Items.Contains(val))
                listBox1.Items.Add(dateTimePicker1.Text);
          
        }


    }
}
