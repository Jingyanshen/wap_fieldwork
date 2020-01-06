using FieldWork.Host.Runtime.Service;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Day
{
    /// <summary>
    /// 每天定时执行巡查概况
    /// </summary>
    public class PatrolSummaryDayJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            PatrolSummaryService _PatrolSummaryService = new PatrolSummaryService();
            _PatrolSummaryService.Run("day");

        }
    }
}
