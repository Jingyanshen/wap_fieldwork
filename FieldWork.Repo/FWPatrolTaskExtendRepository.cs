using SH3H.SDK.DataAccess.Repo;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo
{
    /// <summary>
    /// 
    /// </summary>
    public class FWPatrolTaskExtendRepository : Repository<IFWPatrolTaskExtendStorage>, IFWPatrolTaskExtendRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public FWPatrolTaskSummary GetFWPatrolTaskSummary(string taskid)
        {
            return Storage.GetFWPatrolTaskSummary(taskid);
        }

        /// <summary>
        /// /获取个人巡查概况
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolIndivDto> GetFWPatrolIndivDto(string user, string timeDim)
        {
            return Storage.GetFWPatrolIndivDto(user, timeDim);
        }

        /// <summary>
        /// 获取巡查概况（管理者）
        /// </summary>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolManageDto> GetFWPatrolManageDto(int userId, string timeDim)
        {
            return Storage.GetFWPatrolManageDto(userId,timeDim);
        }

        /// <summary>
        /// 获取计划任务计划小结
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolPlanSummaryDto> GetFWPatrolPlanSummaryDto(string taskid)
        {
            return Storage.GetFWPatrolPlanSummaryDto(taskid);
        }
    }
}
