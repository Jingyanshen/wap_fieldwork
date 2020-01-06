using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 发送短信Dto
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendSmsMessageInDto
    {
        public SendSmsMessageInDto()
        {
            ToUserIds = new List<string>();
        }
        /// <summary>
        /// 消息发送人
        /// </summary>
        [DataMember(Name = "from")]
        public string FromUserId { get; set; }

        /// <summary>
        /// 接收人列表
        /// </summary>
        [DataMember(Name = "to")]
        public List<string> ToUserIds { get; set; }

        /// <summary>
        /// 短信内容
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; set; }
    }
}
