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
    public class FWPatrolIssueRelationDto : DtoBase<FWPatrolIssueRelation, FWPatrolIssueRelationDto>
    {
        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        [DataMember(Name = "issueTypeId")]
        public int IssueTypeId { get; set; }
    }
}
