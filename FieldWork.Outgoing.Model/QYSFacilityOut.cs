using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    /// <summary>
    /// 全要素设备详情
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class QYSFacilityOut
    {
        [DataMember(Name = "facilityId")]
        public string FacilityId { get; set; }

        [DataMember(Name = "facilityName")]
        public string FacilityName { get; set; }


        public static QYSFacilityOut FromDto(FWQYSFacilityDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new QYSFacilityOut()
            {
                FacilityId = dto.FacilityId.ToString(),
                FacilityName = dto.FacilityName.ToString()
            };
        }
    }
}
