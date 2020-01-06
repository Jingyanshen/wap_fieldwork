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
    public class FWPatrolPlanDto : DtoBase<FWPatrolPlan, FWPatrolPlanDto>
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "endTime")]
        public DateTime EndTime { get; set; }

        [DataMember(Name = "inspectNum")]
        public int InspectNum { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "gridId")]
        public int GridId { get; set; }

        [DataMember(Name = "executor")]
        public string Executor { get; set; }

        [DataMember(Name = "executeStation")]
        public int ExecuteStation { get; set; }

        [DataMember(Name = "leader")]
        public string Leader { get; set; }

        [DataMember(Name = "remark")]
        public string Remark { get; set; }

        [DataMember(Name = "creator")]
        public virtual string Creator { get; set; }

        [DataMember(Name = "createTime")]
        public virtual DateTime CreateTime { get; set; }
    }
}
