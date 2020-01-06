using FieldWork.Host.Runtime.Service;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Week
{
    public class PatrolSummaryWeekJob : IJob
    {
        /// <summary>
        /// 每周定时发送巡查概况
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            PatrolSummaryService _PatrolSummaryService = new PatrolSummaryService();
            _PatrolSummaryService.Run("week");
        }
    }
}
