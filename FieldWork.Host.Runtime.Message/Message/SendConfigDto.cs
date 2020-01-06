using System;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 发送配置
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendConfigDto
    {
        /// <summary>
        /// 发送类型
        /// </summary>
        [DataMember(Name = "method")]
        public int SendType { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [DataMember(Name = "planningtime")]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        [DataMember(Name = "retrytimes")]
        public int RetryTime { get; set; }

        /// <summary>
        /// 重试间隔
        /// </summary>
        [DataMember(Name = "retryinterval")]
        public int RetryInterval { get; set; }
    }
}
