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
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.Controllers
{
    [Resource("fwPatrolPlanServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolPlanController : BaseController<IFWPatrolPlanService>
    {
        /// <summary>
        /// POST
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrolPlan")]
        [ActionName("createPartolPlan")]
        public WapResponse<FWPatrolPlanDto> Create([FromBody]FWPatrolPlanDto dto)
        {
            var result = Service.Insert(dto);
            return new WapResponse<FWPatrolPlanDto>(result);
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrolPlans")]
        [ActionName("getPartolPlans")]
        public WapCollection<FWPatrolPlanDto> GetAll()
        {
            var dtos = Service.QueryAll();
            return new WapCollection<FWPatrolPlanDto>(dtos);
        }

        /// <summary>
        /// SOFT DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patrolPlan/{id}/{status}")]
        [ActionName("changePatrolPlanStatus")]
        public WapBoolean ChangePatrolPlanStatus(string id, int status)
        {
            return new WapBoolean(Service.ChangeStatus(id, status));
        }

        /// <summary>
        /// PUT
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patrolPlan")]
        [ActionName("updatePatrolPlan")]
        public WapBoolean UpdatePatrolPlan([FromBody]FWPatrolPlanDto dto)
        {
            var result = Service.Update(dto);
            return new WapBoolean(result);
        }

        /// <summary>
        /// Fuzzy search
        /// </summary>
        /// <param name="gridId"></param>
        /// <param name="patrolType"></param>
        /// <param name="executor"></param>
        /// <param name="startDate"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("patrolPlans/condition")]
        [ActionName("searchPartolPlans")]
        public WapCollection<FWPatrolPlanDto> Search(int gridId, string patrolType, string executor, DateTime startDate, DateTime endTime)
        {
            var planViewModel = new FWPatrolPlanViewModel
            {
                GridId = gridId,
                PatrolTypes = string.IsNullOrEmpty(patrolType) ? new string[0] : patrolType.Split(','),
                Executor = executor,
                StartDate = startDate,
                EndTime = endTime
            };
            return new WapCollection<FWPatrolPlanDto>(Service.Search(planViewModel));
        }
    }
}
