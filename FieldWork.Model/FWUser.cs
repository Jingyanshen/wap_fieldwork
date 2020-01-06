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
    /// 用户表
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 用户组织编码
        /// </summary>
        [DataMember]
        public int StationId { get; set; }

        /// <summary>
        /// 用户组织名称
        /// </summary>
        [DataMember]
        public string StationName { get; set; }

        /// <summary>
        /// 用户激活状态
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// 用户所属网格
        /// </summary>
        [DataMember]
        public int GridId { get; set; }
    }
}
