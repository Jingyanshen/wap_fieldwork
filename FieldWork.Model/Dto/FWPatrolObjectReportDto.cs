using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.Dto
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolObjectReportDto : DtoBase<FWPatrolObjectReport, FWPatrolObjectReportDto>
    {
        [DataMember(Name = "objectId")]
        public int ObjectId { get; set; }

        [DataMember(Name = "issueId")]
        public string IssueId { get; set; }

        [DataMember(Name = "taskId")]
        public string TaskId { get; set; }

        [DataMember(Name = "result")]
        public int Result { get; set; }
    }
}
