using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    [Serializable]
    [DataContract()]
    public class NotifyMessageBase
    {
        public NotifyMessageBase()
        {
            DataList = new List<NotifyContent>();
        }
        [DataMember(Name = "dataList")]
        public List<NotifyContent> DataList { get; set; }

        //这个必须有的属性
        [DataMember(Name = "type")]
        public int? Type { get; set; }
    }

    [Serializable]
    [DataContract()]
    public class NotifyContent
    {
        [DataMember(Name = "issueNum")]
        public string IssueNum { get; set; }
        [DataMember(Name = "odo")]
        public string Odo { get; set; }
        [DataMember(Name = "patrolNum")]
        public string PatrolNum { get; set; }
        [DataMember(Name = "patrolStaff")]
        public string PatrolStaff { get; set; }

    }
}
