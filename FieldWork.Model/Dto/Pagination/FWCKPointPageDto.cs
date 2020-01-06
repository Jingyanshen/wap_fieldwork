using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWCKPointPageDto : PaginationBaseDto
    {
        /// <summary>
        /// 关键词
        /// </summary>
        [DataMember(Name = "key")]
        public string key { get; set; }

    }
}
