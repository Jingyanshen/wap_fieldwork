using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 发送模板消息
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendTemplateMessageInDto
    {
        /// <summary>
        /// 初始化构造器
        /// </summary>
        public SendTemplateMessageInDto()
        {
            Config = new SendConfigDto()
            {
                SendType = 1,
                RetryInterval = 30,
                RetryTime = 3
            };
            Items = new List<ItemDto>();
        }

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
        /// 发送项
        /// </summary>
        [DataMember(Name = "items")]
        public IEnumerable<ItemDto> Items { get; set; }
    }

    /// <summary>
    /// 发送项目录
    /// </summary>
    [Serializable]
    [DataContract()]
    public class ItemDto
    {
        /// <summary>
        /// 发送内容
        /// </summary>
        [DataMember(Name = "data")]
        public string Data { get; set; }

        /// <summary>
        /// 发送目标
        /// </summary>
        [DataMember(Name = "to")]
        public Dictionary<string, List<string>> ToPoints { get; set; }
    }
}
