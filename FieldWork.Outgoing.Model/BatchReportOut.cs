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
    /// 批量设施上报
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class BatchReportOut
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "time")]
        public string Time { get; set; }

        [DataMember(Name = "reportperson")]
        public string ReportPerson { get; set; }

        [DataMember(Name = "wsId")]
        public string WSId { get; set; }

        [DataMember(Name = "patrolObjects")]
        public string PatrolObjects { get; set; }
    }
}
