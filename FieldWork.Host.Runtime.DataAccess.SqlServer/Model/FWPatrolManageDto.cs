using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
    /// <summary>
    /// 巡查概况（管理者）
    /// </summary>
    [Serializable]
    public class FWPatrolManageDto
    {
        /// <summary>
        /// 巡查人
        /// </summary>
        public string patrolStaff { get; set; }

        /// <summary>
        /// 巡查次数
        /// </summary>
        public int patrolNum { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        public decimal odo { get; set; }

        /// <summary>
        /// 上报总数
        /// </summary>
        public int issueNum { get; set; }
    }
}
