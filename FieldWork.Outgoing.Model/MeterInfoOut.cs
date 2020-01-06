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
    /// 水表信息
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class MeterInfoOut
    {
        /// <summary>
        /// 水表编号
        /// </summary>
        [DataMember(Name = "meterId")]
        public string meterId { get; set; }

        /// <summary>
        /// 所属部门编号
        /// </summary>
        [DataMember(Name = "deptId")]
        public string deptId { get; set; }

        /// <summary>
        /// 表码
        /// </summary>
        [DataMember(Name = "meterCode")]
        public string meterCode { get; set; }

        /// <summary>
        /// 密封码
        /// </summary>
        [DataMember(Name = "sealCode")]
        public string sealCode { get; set; }

        /// <summary>
        /// 水表类型编号
        /// </summary>
        [DataMember(Name = "meterTypeId")]
        public string meterTypeId { get; set; }

        /// <summary>
        /// 水表口径编号
        /// </summary>
        [DataMember(Name = "meterDiameterId")]
        public string meterDiameterId { get; set; }

        /// <summary>
        /// 水表口径
        /// </summary>
        [DataMember(Name = "meterDiameterName")]
        public string meterDiameterName { get; set; }

        /// <summary>
        /// 厂家编号
        /// </summary>
        [DataMember(Name = "factoryId")]
        public string factoryId { get; set; }

        /// <summary>
        /// 厂家名称
        /// </summary>
        [DataMember(Name = "factoryName")]
        public string factoryName { get; set; }

        /// <summary>
        /// 水表模型编号
        /// </summary>
        [DataMember(Name = "meterModuleId")]
        public string meterModuleId { get; set; }

        /// <summary>
        /// 水表模型码
        /// </summary>
        [DataMember(Name = "meterModuleCode")]
        public string meterModuleCode { get; set; }
    }
}
