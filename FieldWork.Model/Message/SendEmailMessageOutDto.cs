using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// ID列表对象
    /// </summary>
    [Serializable]
    [DataContract()]
    public class SendEmailMessageOutDto
    {
        /// <summary>
        /// ID列表
        /// </summary>
        [DataMember(Name = "ids")]
        public IEnumerable<string> Ids { get; set; }
    }
}
