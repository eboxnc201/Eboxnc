using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Fasterflect;
using MetroFramework.Forms;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace AttendanceTools
{
    public partial class Main : MetroForm
    {
        public static Main CurrentMain { get; private set; }

        private IList<string> _dateList;
        public IList<string> DateList
        {
            get { return _dateList; }
            set
            {
                this._dateList = value;
                if (value.Any())
                {
                    this.lblweek.Text = string.Join(",", value);
                }
                else
                {

                    this.lblweek.Text = "              ";
                }
            }
        }

        List<AttReportModal> _Reportlist = null;
        private IEnumerable<PersonAtt> _groupList = null;

        List<AttendanceSourceModal> _invalidList = new List<AttendanceSourceModal>();
        public Main()
        {
            InitializeComponent();
            Main.CurrentMain = this;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel) return;
            BtnExport.Enabled = false;
            var filePath = openFile.FileName;
            var dt = ExcelHelper.ExcelToDataSet(filePath).Tables[0];
            var importData = dt.AsEnumerable().Select(s => new AttendanceSourceModal()
            {
                AttNumber = s["考勤号码"].ToString().ConvertTo<int>(),
                PersonName = s["姓名"].ToString(),
                AttTime = s["日期时间"].ToString().ConvertTo<DateTime>()
            }).ToList();
            if (importData.Any())
            {
                dataGridView1.DataSource = importData;
                dataGridView1.Columns[0].HeaderCell.Value = "考勤号码";
                dataGridView1.Columns[1].HeaderCell.Value = "姓名";
                dataGridView1.Columns[2].HeaderCell.Value = "日期时间";
            }
            var groupList = from m in importData
                            group m by new { m.AttNumber, m.PersonName } into g
                            select new PersonAtt()
                            {
                                AttNumber = g.Key.AttNumber,
                                PersonName = g.Key.PersonName,
                                AttTimes = g.ToList().Select(r => r.AttTime).ToList()
                            };
            _groupList = groupList;
            var th = new Thread(LoadData);
            th.Start();
            //t.Thread(LoadData).Start();
            //var list=importData.GroupBy(t=>t.AttNumber)
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (_Reportlist == null)
            {
                MessageBox.Show(@"请先生成考勤数据");
                return;
            }

            var data = ExcelHelper.ToExcelDataFromList("统计", _Reportlist, null, null);
            var fileName = (string.IsNullOrEmpty(this.tbFileName.Text)
 ? DateTime.Now.ToString("yyyyMMddHHmmss")
 : this.tbFileName.Text) ;
            File.WriteAllBytes(fileName + ".xls", data);

            var invaliddata = ExcelHelper.ToExcelDataFromList("只打一次卡", _invalidList, null, null);
            File.WriteAllBytes(fileName + "_Once" + ".xls", invaliddata);
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private void LoadData()
        {

            var reportList = new List<AttReportModal>();
            var count = _groupList.Count();
            var progBar = new ProgressBarHelper(count);
            progBar.OprateProgress += progBar_OprateProgress;
            progBar.Total = count;
            var holidayList = new List<DateTime>();

            if (lblweek.Text.Contains(","))
            {
                holidayList = lblweek.Text.Split(',').ToList().Select(Convert.ToDateTime).ToList();
            }

            for (var i = 0; i < count; i++)
            {
                var personAtt = _groupList.ToList()[i];

                var biz = new BizAttendance(personAtt) { HolidayList = holidayList };
                var invalidAtt = biz.GetInvalidAtt();
                if (invalidAtt != null && invalidAtt.Any())
                {
                    _invalidList.AddRange(
                    invalidAtt.Select(m => new AttendanceSourceModal()
                    {
                        AttNumber = personAtt.AttNumber,
                        PersonName = personAtt.PersonName,
                        AttTime = m
                    }).ToList());
                }
                var mod = new AttReportModal();
                mod.AttNumber = personAtt.AttNumber;
                mod.PersonName = personAtt.PersonName;
                mod.AttDays = biz.GetAttDays();

                var lateDays = biz.GetLateDays();
                mod.LateDays = lateDays.Count();
                mod.LateRemark = string.Join("~", lateDays.Select(p => p.ToString("yyyy-MM-dd")));

                var bigWorkDays = biz.GetBigWork();
                mod.BigWorkDays = bigWorkDays.Count();
                mod.BigWorWorkRemak = string.Join("~", bigWorkDays.Select(p => p.ToString("yyyy-MM-dd")));

                var smallWorkDays = biz.GetSmallWork();
                mod.SmallWorkDays = smallWorkDays.Count();
                mod.SmallWorkRemak = string.Join("~", smallWorkDays.Select(p => p.ToString("yyyy-MM-dd")));

                var middleWorkDays = biz.GetMiddleWork();
                mod.MiddleWorkDays = middleWorkDays.Count;
                mod.MiddleWorkRemak = string.Join("~", middleWorkDays.Select(p => p.ToString("yyyy-MM-dd")));

                var weekSmallDays = biz.GetWeekSmallWorkTime();
                mod.WeekSmallDays = weekSmallDays.Count();
                mod.WeekSmallRemak = string.Join("~", weekSmallDays.Select(p => p.ToString("yyyy-MM-dd")));

                var weekBigDays = biz.GetWeekBigWorkTime();
                mod.WeekBigDays = weekBigDays.Count();
                mod.WeekBigRemak = string.Join("~", weekBigDays.Select(p => p.ToString("yyyy-MM-dd")));

                mod.MealSupplement = BizAttendance.MealSupplement * mod.AttDays;
                mod.TotalMoney = BizAttendance.MealSupplement * mod.AttDays +
                                 BizAttendance.SmallWorkMoney * mod.SmallWorkDays +
                                 BizAttendance.MiddleWorkMoney * mod.MiddleWorkDays +
                                 BizAttendance.BigWorkMoney * mod.BigWorkDays +
                                 BizAttendance.WeekSmallWorkMoney * mod.WeekSmallDays +
                                 BizAttendance.WeekBigWorkMoney * mod.WeekBigDays;
                reportList.Add(mod);
                progBar.Update(i + 1);
                //  Thread.Sleep(100);
            }
            _Reportlist = reportList;

            MethodInvoker invoker = () => this.BtnExport.Enabled = true;
            MethodInvoker gridInvoke = () =>
            {
                this.dataGridView1.DataSource = reportList;
                var propertys = typeof(AttReportModal).GetProperties(Flags.Public | Flags.Instance);
                for (var i = 0; i < propertys.Length; i++)
                {
                    if (propertys[i].HasAttribute<ExportAttribute>())
                    {
                        var attr = propertys[i].Attribute<ExportAttribute>();
                        dataGridView1.Columns[i].HeaderCell.Value = attr.Name;
                    }
                    else
                    {
                        dataGridView1.Columns[i].HeaderCell.Value = "描述";
                    }
                }

            };
            Action a = new Action(() =>
            {
                this.dataGridView1.DataSource = reportList;
                dataGridView1.Update();
            });

            if (this.InvokeRequired)
            {
                // this.Invoke(a);
                this.Invoke(invoker);
                this.Invoke(gridInvoke);
            }
            else
            {
                invoker();
                gridInvoke();
            }
            //MessageBox.Show("数据生成成功");
        }

        void progBar_OprateProgress(long total, long current)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ProgressBarHelper.OnOprateProgress(progBar_OprateProgress), new object[] { total, current });
            }
            else
            {
                this.progressBar1.Maximum = (int)total;
                this.progressBar1.Value = (int)current;
            }
        }

        private void 菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TimeChoose.Single)
            {
                TimeChoose f = new TimeChoose();
                f.lblName = "lblweek";
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            else
            {
                TimeChoose.CurrentTimeChoose.Activate();
            }
        }
    }
}
