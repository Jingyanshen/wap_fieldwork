using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFWPatrolTaskExtendService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        FWPatrolTaskSummaryDto GetFWPatrolTaskSummary(string taskid);

        /// <summary>
        /// /获取个人巡查概况
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolIndivDto> GetFWPatrolIndivDto(string user, string timeDim);

        /// <summary>
        /// 获取巡查概况（管理者）
        /// </summary>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolManageDto> GetFWPatrolManageDto(string user, string timeDim);

        /// <summary>
        /// 获取计划任务计划小结
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolPlanSummaryDto> GetFWPatrolPlanSummaryDto(string taskid);
    }
}
