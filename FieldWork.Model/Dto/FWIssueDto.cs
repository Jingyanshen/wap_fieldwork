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
    public class FWIssueDto : DtoBase<FWIssue, FWIssueDto>
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name = "issueTypeId")]
        public int IssueTypeId { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "reportPerson")]
        public string ReportPerson { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "attachment")]
        public string Attachment { get; set; }

        [DataMember(Name = "extend")]
        public string Extend { get; set; }

        [DataMember(Name = "auditor")]
        public string Auditor { get; set; }

        [DataMember(Name = "auditTime")]
        public DateTime AuditTime { get; set; }

        [DataMember(Name = "auditComment")]
        public string AuditComment { get; set; }

        [DataMember(Name = "formId")]
        public int FormId { get; set; }

        [DataMember(Name = "wsId")]
        public string WSId { get; set; }

        [DataMember(Name = "isBatch")]
        public int IsBatch { get; set; }

        [DataMember(Name = "urgencyLevel")]
        public string UrgencyLevel { get; set; }

        [DataMember(Name = "insertTime")]
        public DateTime InsertTime { get; set; }

        [DataMember(Name = "updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}
