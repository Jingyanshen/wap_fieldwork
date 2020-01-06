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
    /// 巡查概况（个人）
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolIndivOut
    {
        /// <summary>
        /// 
        /// </summary>
        public PatrolIndivOut()
        {
            IssueDetail = new List<IssueDetailOut>();
        }
        /// <summary>
        /// 巡查次数
        /// </summary>
        [DataMember(Name = "patrolNum")]
        public string PatrolNum { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        [DataMember(Name = "odo")]
        public string Odo { get; set; }

        /// <summary>
        /// 上报总数
        /// </summary>
        [DataMember(Name = "issueNum")]
        public string IssueNum { get; set; }

        /// <summary>
        /// 上报详情
        /// </summary>
        [DataMember(Name = "issueDetail")]
        public List<IssueDetailOut> IssueDetail { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class IssueDetailOut
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
        public string Num { get; set; }

    }
}
