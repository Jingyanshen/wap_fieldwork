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
    /// 巡查小结服务
    /// </summary>

    [Resource("fwPatrolTaskExtendServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolTaskExtendController : BaseController<IFWPatrolTaskExtendService>
    {
        /// <summary>
        /// 获取当前任务的巡查小结
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/task/{taskid}/summary")]
        [ActionName("getFWPatrolTaskSummary")]
        public WapResponse<FWPatrolTaskSummaryDto> GetFWPatrolTaskSummary(string taskid)
        {
            var result = Service.GetFWPatrolTaskSummary(taskid);
            return new WapResponse<FWPatrolTaskSummaryDto>(result);
        }

        /// <summary>
        /// 获取巡查概况（个人）
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/indiv_summary")]
        [ActionName("getFWPatrolIndivDto")]
        public WapCollection<FWPatrolIndivDto> GetFWPatrolIndivDto(string user, string timeDim)
        {

            return new WapCollection<FWPatrolIndivDto>(Service.GetFWPatrolIndivDto(user, timeDim));
        }

        /// <summary>
        /// 获取巡查概况（管理者）
        /// </summary>
        /// <param name="user"></param>
        /// <param name="timeDim"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/manage_summary")]
        [ActionName("getFWPatrolManageDto")]
        public WapCollection<FWPatrolManageDto> GetFWPatrolManageDto(string user, string timeDim)
        {

            return new WapCollection<FWPatrolManageDto>(Service.GetFWPatrolManageDto(user, timeDim));
        }

    }
}
