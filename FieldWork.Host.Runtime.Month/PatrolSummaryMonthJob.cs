using FieldWork.Host.Runtime.Service;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Month
{
    public class PatrolSummaryMonthJob : IJob
    {
        /// <summary>
        /// 每月定时执行巡查概况
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            PatrolSummaryService _PatrolSummaryService = new PatrolSummaryService();
            _PatrolSummaryService.Run("month");
        }
    }
}
