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
    public class BatchReportDetailsViewModel
    {
        [DataMember(Name = "objectId")]
        public string ObjectId { get; set; }

        [DataMember(Name = "objectName")]
        public string ObjectName { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "x")]
        public string X { get; set; }

        [DataMember(Name = "y")]
        public string Y { get; set; }

        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
