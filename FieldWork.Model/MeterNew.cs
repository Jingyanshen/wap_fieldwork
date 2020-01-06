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
    /// 新表信息
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class MeterNew
    {
        /// <summary>
        /// 工单编号
        /// </summary>
        [DataMember(Name = "wsId")]
        public string wsId { get; set; }

        /// <summary>
        /// 新表码
        /// </summary>
        [DataMember(Name = "number")]
        public string number { get; set; }

        /// <summary>
        /// Module
        /// </summary>
        [DataMember(Name = "meterModule")]
        public string meterModule { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        [DataMember(Name = "factory")]
        public string factory { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [DataMember(Name = "type")]
        public int type { get; set; }

        /// <summary>
        /// 口径
        /// </summary>
        [DataMember(Name = "caliber")]
        public int caliber { get; set; }

        /// <summary>
        /// 铅封号
        /// </summary>
        [DataMember(Name = "sealNumber")]
        public string sealNumber { get; set; }

        /// <summary>
        /// 旧表编号
        /// </summary>
        [DataMember(Name = "oldMeterNumber")]
        public string oldMeterNumber { get; set; }

        /// <summary>
        /// 处理情况
        /// </summary>
        [DataMember(Name = "disposeSituation")]
        public int disposeSituation { get; set; }
    }
}
