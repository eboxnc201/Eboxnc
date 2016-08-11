using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceTools
{
    public class AttReportModal
    {
        [Export("考勤号码", 0)]
        public int AttNumber { get; set; }
        [Export("姓名", 1)]
        public string PersonName { get; set; }
        [Export("出勤天数", 2)]
        public int AttDays { get; set; }
        [Export("迟到天数", 3, "LateRemark")]
        public int LateDays { get; set; }
        public string LateRemark { get; set; }

        [Export("小加班天数", 4, "SmallWorkRemak")]
        public int SmallWorkDays { get; set; }
        public string SmallWorkRemak { get; set; }

        [Export("中加班天数", 5, "MiddleWorkRemak")]
        public int MiddleWorkDays { get; set; }
        public string MiddleWorkRemak { get; set; }

        [Export("大加班天数", 6, "BigWorWorkRemak")]
        public int BigWorkDays { get; set; }
        public string BigWorWorkRemak { get; set; }

        [Export("周末小加班天数", 7, "WeekSmallRemak")]
        public int WeekSmallDays { get; set; }
        public string WeekSmallRemak { get; set; }

        [Export("周末大加班天数", 8, "WeekBigRemak")]
        public int WeekBigDays { get; set; }
        public string WeekBigRemak { get; set; }

        [Export("餐补", 9)]
        public int MealSupplement { get; set; }
        [Export("总金额", 10)]
        public int TotalMoney { get; set; }
    }
}
