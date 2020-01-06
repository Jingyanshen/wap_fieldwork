using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 发送邮件Dto
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendEmailMessageInDto
    {
        public SendEmailMessageInDto()
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
        /// 邮件主题
        /// </summary>
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// 邮件正文
        /// </summary>
        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}
