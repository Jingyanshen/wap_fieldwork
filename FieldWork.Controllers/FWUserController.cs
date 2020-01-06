using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.SDK.WebApi.Core.Models;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SH3H.WAP.FieldWork.Controllers
{
    /// <summary>
    /// 用户模型
    /// </summary>
    [Resource("fwUserServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWUserController : BaseController<IFWUserService>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user")]
        [ActionName("createFWUser")]
        public WapResponse<FWUserDto> CreateFWUser([FromBody]FWUserDto entity)
        {
            var result = Service.CreateFWUser(entity);
            return new WapResponse<FWUserDto>(result);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("user")]
        [ActionName("updateFWUser")]
        public WapResponse<FWUserDto> UpdateFWUser(int id, FWUserDto entity)
        {
            var result = Service.UpdateFWUser(id, entity);
            return new WapResponse<FWUserDto>(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("user/{id}")]
        [ActionName("deleteFWUser")]
        public WapBoolean DeleteFWUser(int id)
        {
            var result = Service.DeleteFWUser(id);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 查询指定用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{id}")]
        [ActionName("getFWUserById")]
        public WapResponse<FWUserDto> GetFWUserById(int id)
        {
            var result = Service.GetFWUserById(id);
            return new WapResponse<FWUserDto>(result);
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("user/all")]
        [ActionName("getFWUserAll")]
        public WapCollection<FWUserDto> GetFWUserAll()
        {
            var result = Service.GetFWUserAll();
            return new WapCollection<FWUserDto>(result);
        }

        /// <summary>
        /// 根据网格编号获取用户
        /// </summary>
        /// <param name="gridId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{gridId}/grid")]
        [ActionName("getFWUserByGridId")]
        public WapCollection<FWUserDto> GetFWUserByGridId(int gridId)
        {
            var result = Service.GetFWUserByGridId(gridId);
            return new WapCollection<FWUserDto>(result);
        }

        /// <summary>
        /// 根据组织编号获取用户
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{stationId}/station")]
        [ActionName("getFWUserByStationId")]
        public WapCollection<FWUserDto> GetFWUserByStationId(int stationId)
        {
            var result = Service.GetFWUserByStationId(stationId);
            return new WapCollection<FWUserDto>(result);
        }
    }
}
