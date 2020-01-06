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
    /// 用户网格信息
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class UserGridOut
    {
        /// <summary>
        /// 网格编号
        /// </summary>
        [DataMember(Name = "gridId")]
        public string GridId { get; set; }

        /// <summary>
        /// 网格名称
        /// </summary>
        [DataMember(Name = "gridName")]
        public string GridName { get; set; }

        /// <summary>
        /// 所属组织
        /// </summary>
        [DataMember(Name = "stationId")]
        public string StationId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [DataMember(Name = "stationName")]
        public string StationName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static UserGridOut FromDto(FWGridDto dto, FWUserDto userDto)
        {
            if (dto == null)
            {
                return null;
            }
            return new UserGridOut()
            {
                GridId = dto.ID.ToString(),
                GridName = dto.Name,
                StationId = userDto.StationId.ToString(),
                StationName = userDto.StationName,
            };
        }

    }
}
