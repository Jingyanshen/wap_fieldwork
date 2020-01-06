using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 巡查概况（管理者）
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolManageDto
    {
        /// <summary>
        /// 巡查人
        /// </summary>
        [DataMember(Name = "patrolStaff")]
        public string PatrolStaff { get; set; }

        /// <summary>
        /// 巡查次数
        /// </summary>
        [DataMember(Name = "patrolNum")]
        public int PatrolNum { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        [DataMember(Name = "odo")]
        public decimal Odo { get; set; }

        /// <summary>
        /// 上报总数
        /// </summary>
        [DataMember(Name = "issueNum")]
        public int IssueNum { get; set; }
    }
}
