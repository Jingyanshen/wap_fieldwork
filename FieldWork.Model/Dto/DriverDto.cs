using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.Dto
{
    /// <summary>
    /// 司机
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class DriverDto
    {
        /// <summary>
        /// 司机编号
        /// </summary>
        [DataMember(Name = "driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        [DataMember(Name = "driverName")]
        public string DriverName { get; set; }

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
