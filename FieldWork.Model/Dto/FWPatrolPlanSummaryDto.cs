using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 巡查计划统计
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolPlanSummaryDto
    {
        /// <summary>
        /// 巡查计划id
        /// </summary>
        [DataMember(Name = "planId")]
        public string PlanId { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        [DataMember(Name = "planStartTime")]
        public DateTime PlanStartTime { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        [DataMember(Name = "planEndTime")]
        public DateTime PlanEndTime { get; set; }

        /// <summary>
        /// 计划次数
        /// </summary>
        [DataMember(Name = "inspectNum")]
        public int InspectNum { get; set; }

        /// <summary>
        /// 计划完成次数
        /// </summary>
        [DataMember(Name = "complateNum")]
        public int ComplateNum { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember(Name = "gridId")]
        public int GridId { get; set; }
    }
}
