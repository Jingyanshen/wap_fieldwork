using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{

    /// <summary>
    /// 巡查
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolTaskOut
    {
        /// <summary>
        /// 巡查编号
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public string PatrolType { get; set; }

        /// <summary>
        /// 巡查方式
        /// </summary>
        [DataMember(Name = "cruiseType")]
        public string CruiseType { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 巡查人
        /// </summary>
        [DataMember(Name = "patrolStaff")]
        public string PatrolStaff { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember(Name = "startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember(Name = "endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember(Name = "grid")]
        public string Grid { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        [DataMember(Name = "driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        [DataMember(Name = "vehicleNo")]
        public string VehicleNo { get; set; }
    }
}
