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
    /// 管道编号
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model")]
    public class RelationPipeOut
    {
        /// <summary>
        /// 管道编号
        /// </summary>
        [DataMember]
        public string PipeId { get; set; }

        /// <summary>
        /// 管道类型
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 管道地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 管道管径
        /// </summary>
        [DataMember]
        public string Diameter { get; set; }
    }
}
