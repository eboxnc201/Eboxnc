using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceTools
{
    public class ProgressBarHelper
    {
        public long Total { get; set; }
        public long Current { get; set; }

        public ProgressBarHelper(int total)
        {
            Total = total;
        }

        //委托
        public delegate void OnOprateProgress(long total, long current);
        //事件
        public event OnOprateProgress OprateProgress;
        //开始模拟工作
        public void Update(int current)
        {
           
            Current = current;
            if (OprateProgress != null)
                OprateProgress(Total, Current);
        }

    }
}
