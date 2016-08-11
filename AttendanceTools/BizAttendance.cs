using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceTools
{
    public class BizAttendance
    {
        private PersonAtt _personAtt;
        public static int MealSupplement = 5;

        private static int LateHour = 8;
        private static int LateMin = 30;

        private static int EarlyHour = 17;
        private static int EarlyMin = 30;

        private static int SmallWorkhour = 19;
        private static int SmallWorkMin = 30;
        public static int SmallWorkMoney = 5;

        private static int MiddleWorkHour = 20;
        private static int MiddleWorkMin = 30;
        public static int MiddleWorkMoney = 20;

        private static int BigWorkHour = 22;
        private static int BigWorkMin = 30;
        public static int BigWorkMoney = 40;

        private static int WeekSmallWork = 3;
        public static int WeekSmallWorkMoney = 25;

        private static int WeekBigWork = 6;
        public static int WeekBigWorkMoney = 50;

        private List<DateTime> _holidayList = null;



        public List<DateTime> HolidayList
        {
            get { return _holidayList; }
            set { _holidayList = value; }
        }

        public BizAttendance(PersonAtt mod)
        {
            _personAtt = mod;
        }

        static BizAttendance()
        {
            #region 读取配置信息
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("MealSupplement")))
            {
                MealSupplement = int.Parse(CommonHelper.GetConfigData("MealSupplement"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("LateHour")))
            {
                LateHour = int.Parse(CommonHelper.GetConfigData("LateHour"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("LateMin")))
            {
                LateMin = int.Parse(CommonHelper.GetConfigData("LateMin"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("EarlyHour")))
            {
                EarlyHour = int.Parse(CommonHelper.GetConfigData("EarlyHour"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("EarlyMin")))
            {
                EarlyMin = int.Parse(CommonHelper.GetConfigData("EarlyMin"));
            }

            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("SmallWorkhour")))
            {
                SmallWorkhour = int.Parse(CommonHelper.GetConfigData("SmallWorkhour"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("SmallWorkMin")))
            {
                SmallWorkMin = int.Parse(CommonHelper.GetConfigData("SmallWorkMin"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("SmallWorkMoney")))
            {
                SmallWorkMoney = int.Parse(CommonHelper.GetConfigData("SmallWorkMoney"));
            }


            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("MiddleWorkHour")))
            {
                MiddleWorkHour = int.Parse(CommonHelper.GetConfigData("MiddleWorkHour"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("MiddleWorkMin")))
            {
                MiddleWorkMin = int.Parse(CommonHelper.GetConfigData("MiddleWorkMin"));
            } if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("MiddleWorkMoney")))
            {
                MiddleWorkMoney = int.Parse(CommonHelper.GetConfigData("MiddleWorkMoney"));
            }


            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("BigWorkHour")))
            {
                BigWorkHour = int.Parse(CommonHelper.GetConfigData("BigWorkHour"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("BigWorkMin")))
            {
                BigWorkMin = int.Parse(CommonHelper.GetConfigData("BigWorkMin"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("BigWorkMoney")))
            {
                BigWorkMoney = int.Parse(CommonHelper.GetConfigData("BigWorkMoney"));
            }

            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("WeekSmallWork")))
            {
                WeekSmallWork = int.Parse(CommonHelper.GetConfigData("WeekSmallWork"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("WeekSmallWorkMoney")))
            {
                WeekSmallWorkMoney = int.Parse(CommonHelper.GetConfigData("WeekSmallWorkMoney"));
            }

            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("WeekBigWork")))
            {
                WeekBigWork = int.Parse(CommonHelper.GetConfigData("WeekBigWork"));
            }
            if (!string.IsNullOrEmpty(CommonHelper.GetConfigData("WeekBigWorkMoney")))
            {
                WeekBigWorkMoney = int.Parse(CommonHelper.GetConfigData("WeekBigWorkMoney"));
            }
            #endregion
        }


        private IEnumerable<IGrouping<DateTime, DateTime>> _GroupData = null;

        private IEnumerable<IGrouping<DateTime, DateTime>> GroupData
        {
            get
            {
                return _GroupData ?? _personAtt.AttTimes.GroupBy(p => p.Date);
            }
        }


        /// <summary>
        /// 获取出勤天数
        /// </summary>
        /// <returns></returns>
        public int GetAttDays()
        {
            if (_personAtt.AttTimes == null || !_personAtt.AttTimes.Any())
            {
                return 0;
            }

            return _personAtt.AttTimes.GroupBy(p => p.Date).Count(m => HolidayList.All(d => d != m.Key));
        }

        /// <summary>
        /// 获取迟到列表
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetLateDays()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key) || d.ToList().Count < 2)
                {
                    continue;
                }
                var latetime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, LateHour, LateMin, 0);

                var dayAtt = d.ToList().OrderBy(s => s);
                if (dayAtt.First() > latetime)
                {
                    list.Add(d.Key);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取早退列表
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetearlyDays()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key) || d.ToList().Count < 2)
                {
                    continue;
                }
                var earlytime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, EarlyHour, EarlyMin, 0);
                var dayAtt = d.ToList().OrderBy(s => s);
                if (dayAtt.Count() == 1 || dayAtt.Last() < earlytime)
                {
                    list.Add(d.Key);
                }
            }
            return list;
        }

        /// <summary>
        /// 小加班天数
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetSmallWork()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key))
                {
                    continue;
                }
                var smallWorktime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, SmallWorkhour, SmallWorkMin, 0);
                var middleWorktime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, MiddleWorkHour, MiddleWorkMin, 0);
                var dayAtt = d.ToList().OrderBy(s => s);

                if (dayAtt.Last() >= smallWorktime && dayAtt.Last() < middleWorktime)
                {
                    list.Add(d.Key);
                }

            }
            return list;
        }


        /// <summary>
        /// 中加班天数
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetMiddleWork()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key))
                {
                    continue;
                }
                var bigWorktime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, BigWorkHour, BigWorkMin, 0);
                var middleWorktime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, MiddleWorkHour, MiddleWorkMin, 0);
                var dayAtt = d.ToList().OrderBy(s => s);

                if (dayAtt.Last() >= middleWorktime && dayAtt.Last() < bigWorktime)
                {
                    list.Add(d.Key);
                }

            }
            return list;
        }

        /// <summary>
        /// 大加班天数
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetBigWork()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key) || d.ToList().Count < 2)
                {
                    continue;
                }
                var bigWorktime = new DateTime(d.Key.Year, d.Key.Month, d.Key.Day, BigWorkHour, BigWorkMin, 0);
                var dayAtt = d.ToList().OrderBy(s => s);

                if (dayAtt.Last() >= bigWorktime)
                {
                    list.Add(d.Key);
                }

            }
            return list;
        }

        /// <summary>
        /// 获取周末小加班天数
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetWeekSmallWorkTime()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key))
                {
                    var dayAtt = d.ToList().OrderBy(s => s);
                    if (dayAtt.Count() == 1) //只打一次卡不算加班
                    {
                        continue;
                    }
                    var timeSpan = dayAtt.Last() - dayAtt.First();
                    if (timeSpan.Hours >= WeekSmallWork && timeSpan.Hours < WeekBigWork)
                    {
                        list.Add(d.Key);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取周末大加班天数
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetWeekBigWorkTime()
        {
            var list = new List<DateTime>();
            foreach (var d in GroupData)
            {
                if (IsHoliday(d.Key))
                {
                    var dayAtt = d.ToList().OrderBy(s => s);
                    if (dayAtt.Count() == 1) //只打一次卡不算加班
                    {
                        continue;
                    }
                    var timeSpan = dayAtt.Last() - dayAtt.First();
                    if (timeSpan.Hours >= WeekBigWork)
                    {
                        list.Add(d.Key);
                    }
                }

            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsHoliday(DateTime date)
        {
            if (HolidayList != null && HolidayList.Any())
            {
                return HolidayList.Any(m => m == date);
            }
            else
            {
                return date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "SunDay";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetInvalidAtt()
        {
            var list = (from g in GroupData
                        where
                            (g.ToList().Count < 2
                            && g.Key.DayOfWeek != DayOfWeek.Saturday
                            && g.Key.DayOfWeek != DayOfWeek.Sunday)                          
                        select g.ToList().First()).ToList();
            list.AddRange(from g in GroupData from t in g.ToList() where t.Hour > 0 && t.Hour <= 5 select t);

            return list;
        }
    }
}
