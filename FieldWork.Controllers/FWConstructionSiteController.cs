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
    [Resource("fwConstructionSiteServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP + "/constructionSite")]
    public class FWConstructionSiteController : BaseController<IFWConstructionSiteService>
    {
        /// <summary>
        /// 新增工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fwConstructionSite")]
        [ActionName("createFWConstructionSite")]
        public WapResponse<FWConstructionSiteDto> CreateFWConstructionSite([FromBody]FWConstructionSiteDto entity)
        {
            var result = Service.CreateFWConstructionSite(entity);
            return new WapResponse<FWConstructionSiteDto>(result);
        }

        /// <summary>
        /// 更新工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("fwConstructionSite")]
        [ActionName("updateFWConstructionSite")]
        public WapResponse<FWConstructionSiteDto> UpdateFWConstructionSite([FromBody]FWConstructionSiteDto entity)
        {
            var result = Service.UpdateFWConstructionSite(entity.ID,entity);
            return new WapResponse<FWConstructionSiteDto>(result);
        }

        /// <summary>
        /// 删除工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("fwConstructionSite")]
        [ActionName("deleteFWConstructionSite")]
        public WapBoolean DeleteFWConstructionSiteById(int id)
        {
            var result = Service.DeleteFWConstructionSiteById(id);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 获取所有工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fwConstructionSites")]
        [ActionName("getFWConstructionSites")]
        public WapCollection<FWConstructionSiteDto> GetFWConstructionSites()
        {
            var result = Service.GetFWConstructionSites();
            return new WapCollection<FWConstructionSiteDto>(result);
        }

        /// <summary>
        /// 获取目标工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fwConstructionSite")]
        [ActionName("getFWConstructionSite")]
        public WapResponse<FWConstructionSiteDto> GetFWConstructionSiteById(int id)
        {
            var result = Service.GetFWConstructionSiteById(id);
            return new WapResponse<FWConstructionSiteDto>(result);
        }
    }
}
