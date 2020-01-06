using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public abstract class EntityBase
    {
        [DataMember]
        public virtual string Creator { get; set; }

        [DataMember]
        public virtual DateTime CreateTime { get; set; }
    }
}
