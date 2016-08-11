using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceTools
{
    public class AttendanceSourceModal
    {
        [Export("考勤号码", 0)]
        public int AttNumber { get; set; }
        [Export("姓名", 1)]
        public string PersonName { get; set; }
        [Export("打卡时间", 2)]
        public DateTime AttTime { get; set; }
    }

    public class PersonAtt
    {
        public int AttNumber { get; set; }
        public string PersonName { get; set; }
        public List<DateTime> AttTimes { get; set; }
    }
}
