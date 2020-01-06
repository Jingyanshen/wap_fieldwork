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
    public class FWPatrolObjectReport
    {
        [DataMember]
        public int ObjectId { get; set; }

        [DataMember]
        public string IssueId { get; set; }

        [DataMember]
        public string TaskId { get; set; }

        [DataMember]
        public int Result { get; set; }
    }
}
