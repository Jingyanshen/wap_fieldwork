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
    /// 服务控制器
    /// </summary>
    [Resource("fwPatrolTaskCKPointServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolTaskCKPointController : BaseController<IFWPatrolTaskCKPointService>
    {
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patroltask/ckpoint")]
        [ActionName("createFWPatrolTaskCKPoint")]
        public WapResponse<FWPatrolTaskCKPointDto> CreateFWPatrolTaskCKPoint([FromBody]FWPatrolTaskCKPointDto entity)
        {
            var result = Service.CreateFWPatrolTaskCKPoint(entity);
            return new WapResponse<FWPatrolTaskCKPointDto>(result);
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patroltask/ckpoint/{taskid}/{pointid}")]
        [ActionName("updateFWPatrolTaskCKPointById")]
        public WapResponse<FWPatrolTaskCKPointDto> UpdateFWPatrolTaskCKPointById(string taskid, int pointid, [FromBody]FWPatrolTaskCKPointDto entity)
        {
            var result = Service.UpdateFWPatrolTaskCKPointById(taskid, pointid, entity);
            return new WapResponse<FWPatrolTaskCKPointDto>(result);
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("patroltask/ckpoint/{taskid}/{pointid}")]
        [ActionName("deleteFWPatrolTaskCKPointById")]
        public WapBoolean DeleteFWPatrolTaskCKPointById(string taskid, int pointid)
        {
            var result = Service.DeleteFWPatrolTaskCKPointById(taskid, pointid);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 查询全部模型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("patroltask/ckpoint")]
        [ActionName("getFWPatrolTaskCKPointAll")]
        public WapCollection<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointAll()
        {
            var result = Service.GetFWPatrolTaskCKPointAll();
            return new WapCollection<FWPatrolTaskCKPointDto>(result);
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patroltask/ckpoint/{taskid}/{pointid}")]
        [ActionName("getFWPatrolTaskCKPointByTidAndCkPId")]
        public WapResponse<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByTidAndCkPId(string taskid, int pointid)
        {
            var result = Service.GetFWPatrolTaskCKPointByTidAndCkPId(taskid, pointid);
            return new WapResponse<FWPatrolTaskCKPointDto>(result);
        }

        /// <summary>
        /// 根据指定任务编号获取模型列表
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patroltask/ckpoint/{taskid}/task")]
        [ActionName("getFWPatrolTaskCKPointByTid")]
        public WapCollection<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByTid(string taskid)
        {
            var result = Service.GetFWPatrolTaskCKPointByTid(taskid);
            return new WapCollection<FWPatrolTaskCKPointDto>(result);
        }

        /// <summary>
        /// 根据必达点编号获取模型列表
        /// </summary>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patroltask/ckpoint/{pointid}/point")]
        [ActionName("getFWPatrolTaskCKPointByCKid")]
        public WapCollection<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByCKid(int pointid)
        {
            var result = Service.GetFWPatrolTaskCKPointByCKid(pointid);
            return new WapCollection<FWPatrolTaskCKPointDto>(result);
        }

        /// <summary>
        /// 获取模型分页列表
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patroltask/ckpoint/pages")]
        [ActionName("getFWPatrolTaskCKPointPage")]
        public WapResponse<PaginationDto<FWPatrolTaskCKPointDto>> GetFWPatrolTaskCKPointPage([FromUri]FWPatrolTaskCKPointPageDto queryPageDto)
        {
            var result = Service.GetFWPatrolTaskCKPointPage(queryPageDto);
            return new WapResponse<PaginationDto<FWPatrolTaskCKPointDto>>(result);
        }
    }
}
