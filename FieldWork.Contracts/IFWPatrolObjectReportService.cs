using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWPatrolObjectReportService : IServiceBase<FWPatrolObjectReportDto>
    {
        /// <summary>
        /// 批量设施上报
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        string BatchReport(BatchReportViewModel viewModel);

        /// <summary>
        /// 获取批量设施上报对象详情
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        IEnumerable<BatchReportDetailsViewModel> GetIssueObjectsByIssueId(string issueId);
    }
}
