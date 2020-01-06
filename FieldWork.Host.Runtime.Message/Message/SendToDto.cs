using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// 发送目标对象
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendToDto
    {
        /// <summary>
        /// 用户标识，字符串数组
        /// </summary>
        /// 
        [DataMember(Name = "uids")]
        public IEnumerable<string> UserIds { get; set; }

        /// <summary>
        /// 组织标识（用户、工作组、组织结构），字符串数组
        /// </summary>
        [DataMember(Name = "gids")]
        public IEnumerable<string> Organizations { get; set; }

        /// <summary>
        /// 初始化构造器
        /// </summary>
        public SendToDto()
        {
            UserIds = new List<string>();
            Organizations = new List<string>();
        }
    }
}
