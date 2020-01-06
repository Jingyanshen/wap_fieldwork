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
    [Resource("fwPatrolObjectReportServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolObjectReportController : BaseController<IFWPatrolObjectReportService>
    {
        /// <summary>
        /// Create FWPatrolObjectReport
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fwPatrolObjectReport")]
        [ActionName("createFWPatrolObjectReport")]
        public WapResponse<FWPatrolObjectReportDto> Create([FromBody]FWPatrolObjectReportDto dto)
        {
            return new WapResponse<FWPatrolObjectReportDto>(Service.Insert(dto));
        }

        /// <summary>
        /// 批量设施上报
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("issue/batch")]
        [ActionName("issueBatchReport")]
        public WapResponse<string> Create([FromBody]BatchReportViewModel viewModel)
        {
            return new WapResponse<string>(Service.BatchReport(viewModel));
        }

        /// <summary>
        /// 获取批量设施上报对象详情
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("issues/{id}/object")]
        [ActionName("getIssueObjectsByIssueId")]
        public WapCollection<BatchReportDetailsViewModel> GetIssueObjectsByIssueId(string id)
        {
            return new WapCollection<BatchReportDetailsViewModel>(Service.GetIssueObjectsByIssueId(id));
        }
    }
}
