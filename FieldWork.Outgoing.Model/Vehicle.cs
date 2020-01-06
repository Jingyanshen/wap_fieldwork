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
    /// 车辆
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model")]
    public class Vehicle
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [DataMember]
        public string vehicleNo { get; set; }

        /// <summary>
        /// 设备最新时间
        /// </summary>
        [DataMember]
        public DateTime datetime { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        public double x { get; set; }

        /// <summary>
        /// Y
        /// </summary>
        [DataMember]
        public double y { get; set; }
    }
}
