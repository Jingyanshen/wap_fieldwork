using System;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 发送消息
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendMessageInDto
    {
        /// <summary>
        /// 消息发送者
        /// </summary>
        [DataMember(Name = "from")]
        public string FromPointId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [DataMember(Name = "type")]
        public string MessageType { get; set; }

        /// <summary>
        ///发送配置
        /// </summary>
        [DataMember(Name = "config")]
        public SendConfigDto Config { get; set; }

        /// <summary>
        /// 发送配置
        /// </summary>
        [DataMember(Name = "data")]
        public string Data { get; set; }

        /// <summary>
        /// 发送目标
        /// </summary>
        [DataMember(Name = "to")]
        public SendToDto ToPoints { get; set; }

        /// <summary>
        /// 初始化构造器
        /// </summary>
        public SendMessageInDto()
        {
            Config = new SendConfigDto()
            {
                SendType = 1,
                RetryInterval = 30,
                RetryTime = 3
            };
            ToPoints = new SendToDto();
        }
    }
}
