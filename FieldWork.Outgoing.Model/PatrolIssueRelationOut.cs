using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolIssueRelationOut
    {
        [DataMember(Name = "patrolType")]
        public string PatrolType { get; set; }

        [DataMember(Name = "issueTypeId")]
        public string IssueTypeId { get; set; }
    }
}
