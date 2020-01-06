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
    /// 巡查任务模型
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTask
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        [DataMember]
        public String ID { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember]
        public int PatrolType { get; set; }

        /// <summary>
        /// 巡查方式
        /// </summary>
        [DataMember]
        public int CruiseType { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember]
        public string Operator { get; set; }

        /// <summary>
        /// 巡查人，英文逗号分隔
        /// </summary>
        [DataMember]
        public string PatrolStaff { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 结束原因
        /// </summary>
        [DataMember]
        public String EndReason { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember]
        public int GridId { get; set; }

        /// <summary>
        /// 所属计划
        /// </summary>
        [DataMember]
        public String PlanId { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        [DataMember]
        public string Driver { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        [DataMember]
        public string VehicleNo { get; set; }


        //网格信息

        /// <summary>
        /// 网格名称
        /// </summary>
        [DataMember]
        public String GridName { get; set; }

  



    }
}
