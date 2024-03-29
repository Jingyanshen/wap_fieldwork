﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FieldWork.Host.Runtime.Helper
{
    /// <summary>
    /// ID列表对象
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendRabbitMqMessageOutDto
    {
        /// <summary>
        /// ID列表
        /// </summary>
        [DataMember(Name = "ids")]
        public IEnumerable<string> Ids { get; set; }
    }
}
