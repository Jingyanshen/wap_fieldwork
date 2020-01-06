using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWGridBuildTreeDto
    {
        /// <summary>
        /// 
        /// </summary>
        public FWGridBuildTreeDto()
        {
            GridDtos = new List<FWGridDto>();
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "parentId")]
        public int ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "gridDtos")]
        public IEnumerable<FWGridDto> GridDtos { get; set; }
    }
}
