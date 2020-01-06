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
    [Resource("fwIssueServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWIssueController : BaseController<IFWIssueService>
    {
        /// <summary>
        /// Create FWIssue
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fwIssue")]
        [ActionName("createFWIssue")]
        public WapResponse<FWIssueDto> Create([FromBody]FWIssueDto dto)
        {
            return new WapResponse<FWIssueDto>(Service.Insert(dto));
        }
    }
}
