using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 巡查任务分页查询参数模型对象
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolTaskPageDto : PaginationBaseDto
    {
        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember(Name = "grids")]
        public string grids { get; set; }

        /// <summary>
        /// 人员
        /// </summary>
        [DataMember(Name = "users")]
        public string users { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "types")]
        public string types { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember(Name = "startTime")]
        public DateTime startTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember(Name = "endTime")]
        public DateTime endTime { get; set; }


    }
}
