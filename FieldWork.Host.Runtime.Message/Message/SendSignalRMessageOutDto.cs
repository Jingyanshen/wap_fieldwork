using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 发送消息接口返回实体
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendSignalRMessageOutDto
    {
        public SendSignalRMessageOutDto()
        {
            MessageIds = new List<string>();
        }
        /// <summary>
        /// 消息ID
        /// </summary>
        [DataMember(Name = "id")]
        public List<string> MessageIds { get; set; }
    }
}
