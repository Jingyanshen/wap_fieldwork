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
    /// 获取巡查人
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolstaffOut
    {
        /// <summary>
        /// 巡查人编号
        /// </summary>
        [DataMember(Name = "staffId")]
        public string StaffId { get; set; }

        /// <summary>
        /// 巡查人姓名
        /// </summary>
        [DataMember(Name = "staffName")]
        public string StaffName { get; set; }

        /// <summary>
        /// 所属组织
        /// </summary>
        [DataMember(Name = "stationId")]
        public string StationId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [DataMember(Name = "stationName")]
        public string StationName { get; set; }
    }
}
