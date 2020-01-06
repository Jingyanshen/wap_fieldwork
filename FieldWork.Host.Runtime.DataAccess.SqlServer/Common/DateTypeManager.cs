using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
    public class DateTypeManager
    {
        /// <summary>
        /// 获取开始时间
        /// </summary>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetTimeStartByType(PatrolDateTypeEnum type, DateTime time, bool isZeroStart = true)
        {
            if (isZeroStart)
            {
                time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0);
                switch (type)
                {
                    case PatrolDateTypeEnum.Day:
                        return time;
                    case PatrolDateTypeEnum.Week:
                        return time.AddDays(-(int)time.DayOfWeek + 1);
                    case PatrolDateTypeEnum.Month:
                        return time.AddDays(-(int)time.Day + 1);
                    case PatrolDateTypeEnum.Season:
                        var time1 = time.AddMonths(0 - ((time.Month - 1) % 3));
                        return time1.AddDays(-time1.Day + 1);
                    case PatrolDateTypeEnum.Year:
                        return time.AddDays(-(int)time.DayOfYear + 1);
                    default:
                        return time.AddDays(-(int)time.DayOfWeek + 1);
                    //return null;
                }
            }
            else
            {
                switch (type)
                {
                    case PatrolDateTypeEnum.Day:
                        return new DateTime(time.Year, time.Month, time.Day, 0, 0, 0);
                    case PatrolDateTypeEnum.Week:
                        return time.AddDays(-(int)time.DayOfWeek + 1);
                    case PatrolDateTypeEnum.Month:
                        return time.AddDays(-(int)time.Day + 1);
                    case PatrolDateTypeEnum.Season:
                        var time1 = time.AddMonths(0 - ((time.Month - 1) % 3));
                        return time1.AddDays(-time1.Day + 1);
                    case PatrolDateTypeEnum.Year:
                        return time.AddDays(-(int)time.DayOfYear + 1);
                    default:
                        return time.AddDays(-(int)time.DayOfWeek + 1);
                    //return null;
                }
            }

        }

        /// <summary>
        /// 获取结束时间
        /// </summary>
        /// <param name="DataTimeType">Week、Month、Season、Year</param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static DateTime GetTimeEndByType(PatrolDateTypeEnum type, DateTime now, bool isZeroEnd = true)
        {

            if (isZeroEnd)
            {
                now = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
                switch (type)
                {
                    case PatrolDateTypeEnum.Day:
                        return now;
                    case PatrolDateTypeEnum.Week:
                        return now.AddDays(7 - (int)now.DayOfWeek);
                    case PatrolDateTypeEnum.Month:
                        return now.AddMonths(1).AddDays(-now.AddMonths(1).Day + 1).AddDays(-1);
                    case PatrolDateTypeEnum.Season:
                        var time = now.AddMonths((3 - ((now.Month - 1) % 3) - 1));
                        return time.AddMonths(1).AddDays(-time.AddMonths(1).Day + 1).AddDays(-1);
                    case PatrolDateTypeEnum.Year:
                        var time2 = now.AddYears(1);
                        return time2.AddDays(-time2.DayOfYear);
                    default:
                        return now.AddDays(7 - (int)now.DayOfWeek);
                }
            }
            else
            {
                switch (type)
                {
                    case PatrolDateTypeEnum.Day:
                        return now;
                    case PatrolDateTypeEnum.Week:
                        return now.AddDays(7 - (int)now.DayOfWeek);
                    case PatrolDateTypeEnum.Month:
                        return now.AddMonths(1).AddDays(-now.AddMonths(1).Day + 1).AddDays(-1);
                    case PatrolDateTypeEnum.Season:
                        var time = now.AddMonths((3 - ((now.Month - 1) % 3) - 1));
                        return time.AddMonths(1).AddDays(-time.AddMonths(1).Day + 1).AddDays(-1);
                    case PatrolDateTypeEnum.Year:
                        var time2 = now.AddYears(1);
                        return time2.AddDays(-time2.DayOfYear);
                    default:
                        return now.AddDays(7 - (int)now.DayOfWeek);
                }
            }

        }
    }
}
