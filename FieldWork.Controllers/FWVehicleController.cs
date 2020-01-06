using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Share;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SH3H.SDK.WebApi.Core.Models;
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.Controllers
{
    [Resource("fwVehicleServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWVehicleController : BaseController<IFWVehicleService>
    {
        /// <summary>
        /// Create FWVehicle
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fwVehicle")]
        [ActionName("createFWVehicle")]
        public WapResponse<FWVehicleDto> Create([FromBody]FWVehicleDto dto)
        {
            return new WapResponse<FWVehicleDto>(Service.Insert(dto));
        }

        /// <summary>
        /// Set the Active attribute of the FWVehicle table -- soft delete
        /// </summary>
        /// <param name="vehicleNo"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("fwVehicle/{vehicleNo}/{flag}")]
        [ActionName("setFWVehicleFlag")]
        public WapResponse<bool> SetFlag(string vehicleNo, int flag)
        {
            return new WapResponse<bool>(Service.SetFlag(vehicleNo, flag));
        }

        /// <summary>
        /// Update FWVehicle
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("fwVehicle")]
        [ActionName("updateFWVehicle")]
        public WapResponse<bool> Update([FromBody]FWVehicleDto dto)
        {
            return new WapResponse<bool>(Service.Update(dto));
        }

        [HttpPut]
        [Route("fwVehicles/{prevVehicleNo}")]
        [ActionName("updateFWVehicleByVehicleNo")]
        public WapResponse<bool> Update(string prevVehicleNo, [FromBody]FWVehicleDto dto)
        {
            return new WapResponse<bool>(Service.Update(prevVehicleNo, dto));
        }

        /// <summary>
        /// Get All FWVehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwVehicles")]
        [ActionName("getFWVehicles")]
        public WapCollection<FWVehicleDto> GetFWVehicles()
        {
            return new WapCollection<FWVehicleDto>(Service.Query());
        }

        /// <summary>
        /// Get FWVehicles by vehicleNo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwVehicles/{vehicleNo}")]
        [ActionName("getFWVehiclesByVehicleNo")]
        public WapCollection<FWVehicleDto> GetFWVehiclesByVehicleNo(string vehicleNo)
        {
            return new WapCollection<FWVehicleDto>(Service.QueryFWVehiclesByVehicleNo(vehicleNo));
        }

        /// <summary>
        /// 根据站点编码获取车辆信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fwVehicles/{stationId}/station")]
        [ActionName("getVehicleByStationId")]
        public WapCollection<FWVehicleDto> GetVehicleByStationId(int stationId)
        {
            var result = Service.GetVehicleByStationId(stationId);
            return new WapCollection<FWVehicleDto>(result);
        }

        /// <summary>
        /// 获取平台所有司机
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwVehicle/drivers")]
        [ActionName("getAllDrivers")]
        public WapCollection<FWWapUserAndRoleDto> GetAllDrivers()
        {
            return new WapCollection<FWWapUserAndRoleDto>(Service.GetAllDrivers());
        }

        #region 获取车辆信息

        /// <summary>
        /// 获取车辆信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("vehicle")]
        public WapCollection<FWVehicleDto> GetVehicles(string stationId)
        {
            int _stationId = 0;
            int.TryParse(stationId, out _stationId);
            if (_stationId == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "站点编号为空！");
            var allStations = ServiceFactory.GetService<IAuthService>().GetOrganization().ToList();
            var currentStation = allStations.FirstOrDefault(x => x.StationId == _stationId);
            var Stations = new List<FWGridDto>();
            if (null != currentStation)
            {
                if (currentStation.ParentId == -1)
                {
                    Stations = allStations;
                }
                else
                {
                    Stations = allStations.Where(x => x.ParentId == _stationId).ToList();
                    Stations.Add(currentStation);
                }
            }
            //平台获取车辆信息
            var result = ServiceFactory.GetService<IFWVehicleService>().GetVehicleByStationId(Stations);

            return new WapCollection<FWVehicleDto>(result);
        }

        #endregion

        #region 获取司机

        /// <summary>
        /// 司机信息
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("driver")]
        public WapCollection<DriverDto> GetDrivers(string stationId)
        {
            var driverRoleValue = ConfigurationSettings.AppSettings["WAP_DRIVER_ROLE"];
            int _stationId = 0;
            int.TryParse(stationId, out _stationId);
            List<DriverDto> driverOuts = new List<DriverDto>();


            //获取所有司机人员信息
            var wapUsers = ServiceFactory.GetService<IFWWapUserAndRoleService>().GetFWWapUserAndRoleDtoAll();
            if (wapUsers == null || wapUsers.Count() <= 0)
                return new WapCollection<DriverDto>(driverOuts);

            if (_stationId == 0)
            {

                var users = wapUsers.Where(p => p.RoleId == Convert.ToInt32(driverRoleValue)).ToList();//过滤司机角色

                if (users != null && users.Count() > 0)
                {
                    foreach (var user in wapUsers)
                    {
                        DriverDto driverOut = new DriverDto()
                        {
                            Driver = user.UserId.ToString(),
                            DriverName = user.UserName,
                            StationId = user.OrganizationId.ToString(),
                            StationName = user.OrganizationName,
                        };
                        driverOuts.Add(driverOut);
                    }
                }

            }
            else
            {
                //获取指定网格及以下递归网格的司机
                var users = ServiceFactory.GetService<IFWUserService>().GetFWUserByRoleAndOrgId(Convert.ToInt32(driverRoleValue), _stationId);
                if (users != null && users.Count() > 0)
                {
                    foreach (var item in users)
                    {
                        DriverDto driverOut = new DriverDto()
                        {
                            Driver = item.Id.ToString(),
                            DriverName = item.Name,
                            StationId = item.StationId.ToString(),
                            StationName = item.StationName,
                        };
                        driverOuts.Add(driverOut);
                    }
                }
            }
            return new WapCollection<DriverDto>(driverOuts);
        }

        #endregion
    }
}
