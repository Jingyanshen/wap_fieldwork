using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 巡查计划
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolPlan : EntityBase
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int PatrolType { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public int InspectNum { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int GridId { get; set; }

        [DataMember]
        public string Executor { get; set; }

        [DataMember]
        public int ExecuteStation { get; set; }

        [DataMember]
        public string Leader { get; set; }

        [DataMember]
        public string Remark { get; set; }
    }
}
