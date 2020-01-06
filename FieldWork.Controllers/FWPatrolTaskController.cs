using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.SDK.WebApi.Core.Models;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;
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
    [Resource("fwPatrolTaskServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolTaskController : BaseController<IFWPatrolTaskService>
    {
        /// <summary>
        /// 新增巡查任务模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrol/task")]
        [ActionName("createFWPatrolTask")]
        public WapResponse<FWPatrolTaskDto> CreateFWPatrolTask([FromBody]FWPatrolTaskDto entity)
        {
            var result = Service.CreateFWPatrolTask(entity);
            return new WapResponse<FWPatrolTaskDto>(result);
        }

        /// <summary>
        /// 修改巡查任务模型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patrol/task/{id}")]
        [ActionName("updateFWPatrolTaskById")]
        public WapResponse<FWPatrolTaskDto> UpdateFWPatrolTaskById(String id, [FromBody]FWPatrolTaskDto entity)
        {
            var result = Service.UpdateFWPatrolTaskById(id, entity);
            return new WapResponse<FWPatrolTaskDto>(result);
        }

        /// <summary>
        /// 删除指定巡查任务模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("patrol/task/{id}")]
        [ActionName("deleteFWPatrolTaskById")]
        public WapBoolean DeleteFWPatrolTaskById(String id)
        {
            var result = Service.DeleteFWPatrolTaskById(id);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 获取巡查任务全部模型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/task")]
        [ActionName("getFWPatrolTaskAll")]
        public WapCollection<FWPatrolTaskDto> GetFWPatrolTaskAll()
        {
            var result = Service.GetFWPatrolTaskAll();
            return new WapCollection<FWPatrolTaskDto>(result);
        }

        /// <summary>
        /// 获取指定巡查任务模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/task/{id}")]
        [ActionName("getFWPatrolTaskById")]
        public WapResponse<FWPatrolTaskDto> GetFWPatrolTaskById(String id)
        {
            var result = Service.GetFWPatrolTaskById(id);
            return new WapResponse<FWPatrolTaskDto>(result);
        }

        /// <summary>
        /// 分页查询巡查任务模型
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/task/pages")]
        [ActionName("queryFWPatrolTaskPage")]
        public WapResponse<PaginationDto<FWPatrolTaskDto>> QueryFWPatrolTaskPage([FromUri]FWPatrolTaskPageDto queryPageDto)
        {
            var result = Service.QueryFWPatrolTaskPage(queryPageDto);
            return new WapResponse<PaginationDto<FWPatrolTaskDto>>(result);
        }

        /// <summary>
        /// 获取当前任务的必达点和必达点状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/task/{id}/points")]
        [ActionName("getFWCKPointDto")]
        public WapResponse<PaginationDto<FWCKPointDto>> GetFWCKPointDto(string id, [FromUri]FWCKPointPageDto queryDto)
        {
            var result = Service.GetFWCKPointDto(id, queryDto);
            return new WapResponse<PaginationDto<FWCKPointDto>>(result);
        }

        /// <summary>
        /// 获取巡查上报列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/{id}/issue")]
        [ActionName("getIssuesByTaskId")]
        public WapCollection<FWIssueViewModel> GetIssuesByTaskId(string id)
        {
            var result = Service.GetIssuesByTaskId(id);
            return new WapCollection<FWIssueViewModel>(result);
        }
    }
}
