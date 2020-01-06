using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.ViewModels
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class BatchReportViewModel
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "time")]
        public string Time { get; set; }

        [DataMember(Name = "reportPerson")]
        public string ReportPerson { get; set; }

        [DataMember(Name = "wsId")]
        public string WSId { get; set; }

        [DataMember(Name = "patrolObjects")]
        public IList<PatrolObjectReportViewModel> PatrolObjectReportViewModels { get; set; }
    }

    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class PatrolObjectReportViewModel
    {
        [DataMember(Name = "objectId")]
        public string ObjectId { get; set; }

        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
