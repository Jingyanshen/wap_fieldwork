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
    [Resource("fwPatrolGISRelationServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolGISRelationController : BaseController<IFWPatrolGISRelationService>
    {
        /// <summary>
        /// Get All FWPatrolGISRelations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwPatrolGISRelations")]
        [ActionName("getFWPatrolGISRelations")]
        public WapCollection<FWPatrolGISRelationDto> GetFWPatrolGISRelations()
        {
            return new WapCollection<FWPatrolGISRelationDto>(Service.Query());
        }

        /// <summary>
        /// Get FWPatrolGISRelations By PatrolType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwPatrolGISRelations/{patrolType}")]
        [ActionName("getFWPatrolGISRelationByPatrolType")]
        public WapCollection<FWPatrolGISRelationDto> GetFWPatrolGISRelationsByPatrolType(int patrolType)
        {
            return new WapCollection<FWPatrolGISRelationDto>(Service.GetFWPatrolGISRelationsByPatrolType(patrolType));
        }
    }
}
