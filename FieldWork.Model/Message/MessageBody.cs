using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    public class MessageBody
    {
        public MessageBody()
        {
            Items = new List<ItemDto>();
        }
        /// <summary>
        /// 发送项
        /// </summary>
        [DataMember(Name = "items")]
        public IEnumerable<ItemDto> Items { get; set; }
    }
}
