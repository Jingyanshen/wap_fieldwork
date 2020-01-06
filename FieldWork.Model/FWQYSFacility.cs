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
     /// 全要素设备详情
     /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWQYSFacility
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember]
        public string FacilityId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [DataMember]
        public string FacilityName { get; set; }

        /// <summary>
        /// 绑定用户ID
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// 绑定用户账号
        /// </summary>
        [DataMember]
        public string UserAccount { get; set; }

        /// <summary>
        /// 绑定用户名称
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 用户绑定类型(1:联系人,2:责任人)
        /// </summary>
        [DataMember]
        public int Type { get; set; }
    }
}
