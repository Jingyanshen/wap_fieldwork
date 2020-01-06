using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    /// <summary>
    /// 到场时间
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class ArriveTimeOut
    {
        /// <summary>
        /// 时间
        /// </summary>
        [DataMember(Name = "time")]
        public string Time { get; set; }
    }
}
