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

namespace SH3H.WAP.FieldWork.Controllers
{
    [Resource("fwPatrolCKPointServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolCKPointController : BaseController<IFWPatrolCKPointService>
    {
        /// <summary>
        /// POST
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrolCKPoint")]
        [ActionName("createPartolCKPoint")]
        public WapResponse<FWPatrolCKPointDto> Create([FromBody]FWPatrolCKPointDto dto)
        {
            var result = Service.Insert(dto);
            return new WapResponse<FWPatrolCKPointDto>(result);
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrolCKPoints")]
        [ActionName("getPatrolCKPoints")]
        public WapCollection<FWPatrolCKPointDto> GetPatrolCKPoints(int gridId, string name)
        {
            var dtos = Service.Query(gridId, name);
            return new WapCollection<FWPatrolCKPointDto>(dtos);
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("patrolCKPoint/{id}")]
        [ActionName("deletePatrolCKPoint")]
        public WapBoolean DeletePatrolPlan(int id)
        {
            return new WapBoolean(Service.Delete(id));
        }

        /// <summary>
        /// PUT
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patrolCKPoint")]
        [ActionName("updatePatrolCKPoint")]
        public WapBoolean UpdatePatrolPlan([FromBody]FWPatrolCKPointDto dto)
        {
            var result = Service.Update(dto);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 根据网格ID查询必达点
        /// </summary>
        /// <param name="GridId">网格ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrolCKPoints/{gridId}")]
        [ActionName("getPointByGridId")]
        public WapCollection<FWPatrolCKPointDto> GetPointByGridId(int gridId)
        {
            var dtos = Service.GetPointByGridId(gridId);
            return new WapCollection<FWPatrolCKPointDto>(dtos);
        }
    }
}
