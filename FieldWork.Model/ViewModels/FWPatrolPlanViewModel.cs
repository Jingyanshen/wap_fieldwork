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
    public class FWPatrolPlanViewModel
    {
        [DataMember(Name = "gridId")]
        public int GridId { get; set; }

        [DataMember(Name = "patrolType")]
        public string[] PatrolTypes { get; set; }

        [DataMember(Name = "executor")]
        public string Executor { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "endTime")]
        public DateTime EndTime { get; set; }
    }
}
