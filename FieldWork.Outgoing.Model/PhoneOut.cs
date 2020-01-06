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
    /// 联系方式
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class PhoneOut
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
    }
}
