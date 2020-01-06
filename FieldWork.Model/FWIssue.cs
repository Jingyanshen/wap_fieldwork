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
    public class FWIssue
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int IssueTypeId { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public string ReportPerson { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string Attachment { get; set; }

        [DataMember]
        public string Extend { get; set; }

        [DataMember]
        public string Auditor { get; set; }

        [DataMember]
        public DateTime AuditTime { get; set; }

        [DataMember]
        public string AuditComment { get; set; }

        [DataMember]
        public int FormId { get; set; }

        [DataMember]
        public string WSId { get; set; }

        [DataMember]
        public int IsBatch { get; set; }

        [DataMember]
        public string UrgencyLevel { get; set; }

        [DataMember]
        public DateTime InsertTime { get; set; }

        [DataMember]
        public DateTime UpdateTime { get; set; }

    }
}
