using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolIssueRelation
    {
        [DataMember]
        public int PatrolType { get; set; }
        
        [DataMember]
        public int IssueTypeId { get; set; }
    }
}
