using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.FieldWork.Model.Dto;
using System.Configuration;

namespace SH3H.WAP.FieldWork.Service
{
    public class FWVehicleService : BaseService, IFWVehicleService
    {
        private IFWVehicleRepository _fwVehicleRepository;

        private IFWWapUserAndRoleRepository _fwWapUserAndRoleRepository;

        public FWVehicleService(IFWVehicleRepository fwVehicleRepository, IFWWapUserAndRoleRepository fwWapUserAndRoleRepository)
        {
            _fwVehicleRepository = fwVehicleRepository;
            _fwWapUserAndRoleRepository = fwWapUserAndRoleRepository;
        }

        public bool SetFlag(string vehicleNo, int flag)
        {
            return _fwVehicleRepository.SetFlag(vehicleNo, flag);
        }

        public FWVehicleDto Insert(FWVehicleDto dto)
        {
            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");
            return FWVehicleDto.FromModel(_fwVehicleRepository.Insert(dto.ToModel(dto)));
        }

        public bool Update(FWVehicleDto dto)
        {
            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");
            return _fwVehicleRepository.Update(dto.ToModel(dto));
        }

        public IEnumerable<FWVehicleDto> Query()
        {
            return _fwVehicleRepository.Query().Select(x => FWVehicleDto.FromModel(x));
        }


        public IEnumerable<FWVehicleDto> QueryFWVehiclesByVehicleNo(string vehicleNo)
        {
            return _fwVehicleRepository.QueryFWVehiclesByVehicleNo(vehicleNo).Select(x => FWVehicleDto.FromModel(x));
        }

        /// <summary>
        /// 根据站点编码获取车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicleDto> GetVehicleByStationId(int stationId)
        {
            if (stationId <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "站点编码为空！");
            var result = _fwVehicleRepository.GetVehicleByStationId(stationId);
            return result.Select(p => FWVehicleDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 根据站点编号获取子集站点的车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicleDto> GetVehicleByStationId(List<FWGridDto> stationId)
        {
            if (stationId.Count <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "站点编码为空！");
            var result = _fwVehicleRepository.GetVehicleByStationId(stationId);
            return result.Select(p => FWVehicleDto.FromModel(p)).ToList();
        }


        /// <summary>
        ///  获取指定站点下的司机
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWVehicleDto> GetFWVehicleDriversByStationId(int stationId = 0)
        {
            //if (stationId <= 0)
            //    throw new WapException(StateCode.CODE_ARGUMENT_NULL, "站点编码为空！");
            var result = _fwVehicleRepository.GetFWVehicleDriversByStationId(stationId);
            return result.Select(p => FWVehicleDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取平台所有司机
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetAllDrivers()
        {
            var driverRoleValue = ConfigurationSettings.AppSettings["WAP_DRIVER_ROLE"];
            return _fwWapUserAndRoleRepository.GetFWWapUserAndRoleDtoAll().Where(x => x.RoleId == int.Parse(driverRoleValue)).ToList();
        }


        public bool Update(string prevVehicleNo, FWVehicleDto dto)
        {
            if (string.IsNullOrEmpty(prevVehicleNo))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "要修改的车牌号为空！");

            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            return _fwVehicleRepository.Update(prevVehicleNo, dto.ToModel(dto));
        }
    }
}
