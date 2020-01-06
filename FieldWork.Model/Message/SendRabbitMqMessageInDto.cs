using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 发送短信Dto
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendRabbitMqMessageInDto
    {
        public SendRabbitMqMessageInDto()
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
        /// 手机app消息数据
        /// </summary>
        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
