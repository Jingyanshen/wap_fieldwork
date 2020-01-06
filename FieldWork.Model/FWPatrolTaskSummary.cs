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
    /// 巡查小结
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskSummary
    {
        /// <summary>
        /// 巡查方式
        /// </summary>
        [DataMember]
        public int CruiseType { get; set; }

        /// <summary>
        /// 用时
        /// </summary>
        [DataMember]
        public string PatrolTime { get; set; }

        /// <summary>
        /// 公里数
        /// </summary>
        [DataMember]
        public decimal Mileage { get; set; }

        /// <summary>
        /// 发现问题数
        /// </summary>
        [DataMember]
        public int Issues { get; set; }

        /// <summary>
        /// 事件数
        /// </summary>
        [DataMember]
        public int IssueEvents { get; set; }

        /// <summary>
        /// 设施数
        /// </summary>
        [DataMember]
        public int IssueEquipment { get; set; }

        /// <summary>
        /// 必达点数
        /// </summary>
        [DataMember]
        public int ClockPoint { get; set; }

        /// <summary>
        /// 必达点已签到
        /// </summary>
        [DataMember]
        public int ClockOn { get; set; }

        /// <summary>
        /// 必达点未签到
        /// </summary>
        [DataMember]
        public int UnClockOn { get; set; }
    }
}
