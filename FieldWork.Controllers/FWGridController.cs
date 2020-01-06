using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SH3H.SDK.WebApi.Core.Models;

namespace SH3H.WAP.FieldWork.Controllers
{
    /// <summary>
    /// AppRegister服务控制器
    /// </summary>
    [Resource("fwGridServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP + "/grid")]
    public class FWGridController : BaseController<IFWGridService>
    {
        /// <summary>
        /// 新增网格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fwGrid")]
        [ActionName("createFWGrid")]
        public WapResponse<FWGridDto> CreateFWGrid([FromBody]FWGridDto entity)
        {
            var result = Service.CreateFWGrid(entity);
            return new WapResponse<FWGridDto>(result);
        }

        /// <summary>
        /// 更新网格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("fwGrid")]
        [ActionName("updateFWGrid")]
        public WapResponse<FWGridDto> UpdateFWGrid([FromBody]FWGridDto entity)
        {
            var result = Service.UpdateFWGridById(entity.ID, entity);
            return new WapResponse<FWGridDto>(result);
        }

        /// <summary>
        /// 根据编号删除网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("fwGrids/{id}")]
        [ActionName("deleteFWGridById")]
        public WapBoolean DeleteFWGridById(Int32 id)
        {
            var result = Service.DeleteFWGridById(id);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 根据编号获取网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fwGrids/{id}")]
        [ActionName("getFWGridById")]
        public WapResponse<FWGridDto> GetFWGridById(Int32 id)
        {
            var result = Service.GetFWGridById(id);
            return new WapResponse<FWGridDto>(result);
        }

        /// <summary>
        /// 获取全部网格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwGrids")]
        [ActionName("getFWGridAll")]
        public WapCollection<FWGridDto> GetFWGridAll()
        {
            var result = Service.GetFWGridAll();
            return new WapCollection<FWGridDto>(result);
        }

        /// <summary>
        /// 获取网格geoJson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getgeojson")]
        [ActionName("getGeoJsonById")]
        public string GetGeoJsonById(int id)
        {
            var result = Service.GetGeoJsonById(id);
            return result;
        }
        /// <summary>
        /// 获取人员所在组织以及子组织网格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwGrids/{userid}/user")]
        [ActionName("getFWGridByUserId")]
        public WapResponse<FWGridBuildTreeDto> GetFWGridByUserId(int userid)
        {

            var result = Service.GetFWGridByUserId(userid);
            return new WapResponse<FWGridBuildTreeDto>(result);
        }

        /// <summary>
        /// 根据当前登录用户组织信息获取其下网格
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("grids/{orgId}")]
        [ActionName("getGridsByOrgId")]
        public WapCollection<FWGridDto> GetGridsByOrgId(int orgId)
        {
            return new WapCollection<FWGridDto>(Service.GetFWGridsByOrgId(orgId));
        }
    }
}
