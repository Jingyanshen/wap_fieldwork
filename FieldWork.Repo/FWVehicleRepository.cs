using SH3H.SDK.DataAccess.Repo;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo
{
    public class FWVehicleRepository : Repository<IFWVehicleStorage>, IFWVehicleRepository
    {
        public bool SetFlag(string vehicleNo, int flag)
        {
            return Storage.SetFlag(vehicleNo, flag);
        }

        public FWVehicle Insert(FWVehicle entity)
        {
            return Storage.Insert(entity);
        }

        public bool Update(FWVehicle entity)
        {
            return Storage.Update(entity);
        }

        public IEnumerable<FWVehicle> Query()
        {
            return Storage.Query();
        }

        /// <summary>
        /// 根据站点编码获取车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicle> GetVehicleByStationId(int stationId)
        {
            return Storage.GetVehicleByStationId(stationId);
        }

        /// <summary>
        /// 根据站点编号获取子集站点的车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicle> GetVehicleByStationId(List<FWGridDto> stationId)
        {
            return Storage.GetVehicleByStationId(stationId);
        }


        public IEnumerable<FWVehicle> QueryFWVehiclesByVehicleNo(string vehicleNo)
        {
            return Storage.QueryFWVehiclesByVehicleNo(vehicleNo);
        }


        /// <summary>
        ///  获取指定站点下的司机
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicle> GetFWVehicleDriversByStationId(int stationId = 0)
        {
            return Storage.GetFWVehicleDriversByStationId(stationId);
        }


        public bool Update(string prevVehicleNo, FWVehicle entity)
        {
            return Storage.Update(prevVehicleNo, entity);
        }
    }
}
