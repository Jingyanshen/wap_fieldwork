using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 必达点打卡
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskCKPointPageDto : PaginationBaseDto
    {
        /// <summary>
        /// 关键词
        /// </summary>
        [DataMember(Name = "key")]
        public string key { get; set; }

        /// <summary>
        /// 必达点
        /// </summary>
        [DataMember(Name = "ckpointId")]
        public int ckpointId { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        [DataMember(Name = "ckpointTime")]
        public DateTime ckpointTime { get; set; }
    }
}
