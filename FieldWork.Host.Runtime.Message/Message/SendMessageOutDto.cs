using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 发送消息返回值
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendMessageOutDto
    {
        /// <summary>
        /// 消息id列表
        /// </summary>
        [DataMember(Name = "Ids")]
        public IEnumerable<string> MessageIds { get; set; }
    }
}
