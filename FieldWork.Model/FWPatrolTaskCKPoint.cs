
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 必达点打卡模型
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskCKPoint
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        [DataMember]
        public String TaskId { get; set; }

        /// <summary>
        /// 必达点编号
        /// </summary>
        [DataMember]
        public int CKPonitId { get; set; }

        /// <summary>
        /// 打卡状态
        /// </summary>
        [DataMember]
        public bool Status { get; set; }

        /// <summary>
        /// 打卡次数
        /// </summary>
        [DataMember]
        public int CheckInNum { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        [DataMember]
        public DateTime CheckInTime { get; set; }

        /// <summary>
        /// 打卡点X坐标
        /// </summary>
        [DataMember]
        public decimal CheckInX { get; set; }

        /// <summary>
        /// 打卡点Y坐标
        /// </summary>
        [DataMember]
        public decimal CheckInY { get; set; }

        //关联表

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember]
        public int PatrolType { get; set; }

        /// <summary>
        /// 必达点名称
        /// </summary>
        [DataMember]
        public string CKPointName { get; set; }
    }
}
