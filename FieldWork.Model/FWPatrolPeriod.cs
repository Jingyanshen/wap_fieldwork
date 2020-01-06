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
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWPatrolPeriod
    {
        /// <summary>
        /// 周期编号
        /// </summary>
        [DataMember]
        public int PeriodId { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        [DataMember]
        public int PeriodBase { get; set; }

        /// <summary>
        /// 周期间隔
        /// </summary>
        [DataMember]
        public int Interval { get; set; }
    }
}
