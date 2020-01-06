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
    /// 巡查概况（个人）
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolIndivDto
    {

        /// <summary>
        /// 巡查次数
        /// </summary>
        [DataMember(Name = "patrolNum")]
        public int PatrolNum { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        [DataMember(Name = "odo")]
        public decimal Odo { get; set; }

        /// <summary>
        /// 上报总数
        /// </summary>
        [DataMember(Name = "issueNum")]
        public int IssueNum { get; set; }

        ///// <summary>
        ///// 上报详情
        ///// </summary>
        //[DataMember(Name = "issueDetail")]
        //public IEnumerable<FWIssueDetailDto> IssueDetail { get; set; }

        /// <summary>
        /// 上报类型；语义描述，如：井盖移位
        /// </summary>
        [DataMember(Name = "issue")]
        public string Issue { get; set; }

        /// <summary>
        /// 上报数
        /// </summary>
        [DataMember(Name = "num")]
        public int Num { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWIssueDetailDto
    {
        /// <summary>
        /// 上报类型；语义描述，如：井盖移位
        /// </summary>
        [DataMember(Name = "issue")]
        public string Issue { get; set; }

        /// <summary>
        /// 上报数
        /// </summary>
        [DataMember(Name = "num")]
        public int Num { get; set; }

    }
}
