using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    /// <summary>
    /// 巡查车辆
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class VehicleOut
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [DataMember(Name = "vehicleNo")]
        public string VehicleNo { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

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
        /// 默认司机编号
        /// </summary>
        [DataMember(Name = "driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 默认司机名称
        /// </summary>
        [DataMember(Name = "driverName")]
        public string DriverName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static VehicleOut FromDto(FWVehicleDto dto)
        {
            if (dto == null)
                return null;
            return new VehicleOut()
            {
                Driver = dto.Driver,
                DriverName = dto.DriverName,
                StationId = dto.StationId.ToString(),
                StationName = dto.StationName,
                Type = dto.Type.ToString(),
                VehicleNo = dto.VehicleNo,
            };
        }
    }
}
