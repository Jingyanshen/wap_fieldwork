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
    /// 新建水表信息
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class MeterOut
    {
        /// <summary>
        /// 新水表表码
        /// </summary>
        [DataMember(Name = "meterCode")]
        public string meterCode { get; set; }

        /// <summary>
        /// 新水表口径
        /// </summary>
        [DataMember(Name = "meterDiameterId")]
        public string meterDiameterId { get; set; }

        /// <summary>
        /// 新水表产家
        /// </summary>
        [DataMember(Name = "factoryName")]
        public string factoryName { get; set; }

        /// <summary>
        /// 新水表类型
        /// </summary>
        [DataMember(Name = "meterTypeId")]
        public string meterTypeId { get; set; }

        /// <summary>
        /// 新水表型号
        /// </summary>
        [DataMember(Name = "meterModuleCode")]
        public string meterModuleCode { get; set; }

        /// <summary>
        /// 新水表铅封号
        /// </summary>
        [DataMember(Name = "sealCode")]
        public string sealCode { get; set; }

        /// <summary>
        /// 旧水表编号
        /// </summary>
        [DataMember(Name = "oldMeterId")]
        public string oldMeterId { get; set; }
    }
}
