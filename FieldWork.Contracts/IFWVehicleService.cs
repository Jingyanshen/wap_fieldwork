using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWVehicleService : IServiceBase<FWVehicleDto>
    {
        bool SetFlag(string vehicleNo, int flag);

        bool Update(string prevVehicleNo, FWVehicleDto dto);

        IEnumerable<FWVehicleDto> QueryFWVehiclesByVehicleNo(string vehicleNo);

        /// <summary>
        /// 根据站点编码获取车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWVehicleDto> GetVehicleByStationId(int stationId);

        /// <summary>
        /// 根据站点编号获取子集站点的车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWVehicleDto> GetVehicleByStationId(List<FWGridDto> stationId);

        /// <summary>
        ///  获取指定站点下的司机
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWVehicleDto> GetFWVehicleDriversByStationId(int stationId = 0);

        /// <summary>
        /// 获取平台所有司机
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWWapUserAndRoleDto> GetAllDrivers();
    }
}
