using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
    public interface IPatrolSummaryStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">管理员</param>
        /// <param name="timeDim">参数：Day、Week、Month</param>
        /// <returns></returns>
        IEnumerable<FWPatrolManageDto> GetPatrolManage(int userId, string timeDim);
    }
}
