using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    public interface IFWVehicleRepository : IRepositoryBase<FWVehicle>
    {
        bool SetFlag(string vehicleNo, int flag);

        bool Update(string prevVehicleNo, FWVehicle entity);

        IEnumerable<FWVehicle> QueryFWVehiclesByVehicleNo(string vehicleNo);

        /// <summary>
        /// 根据站点编码获取车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWVehicle> GetVehicleByStationId(int stationId);

        /// <summary>
        /// 根据站点编号获取子集站点的车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWVehicle> GetVehicleByStationId(List<FWGridDto> stationId);

        /// <summary>
        ///  获取指定站点下的司机
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWVehicle> GetFWVehicleDriversByStationId(int stationId = 0);
    }
}
