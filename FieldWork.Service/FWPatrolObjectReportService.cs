using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.Service
{
    public class FWPatrolObjectReportService : BaseService, IFWPatrolObjectReportService
    {

        private IFWPatrolObjectReportRepository _fwPatrolObjectReportRepository;

        private IFWIssueService _fwIssueService;

        public FWPatrolObjectReportService(IFWPatrolObjectReportRepository fwPatrolObjectReportRepository, IFWIssueService fwIssueService)
        {
            _fwPatrolObjectReportRepository = fwPatrolObjectReportRepository;
            _fwIssueService = fwIssueService;
        }

        /// <summary>
        /// 批量设施上报
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public string BatchReport(BatchReportViewModel viewModel)
        {
            if (viewModel == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "批量设施上报对象模型为空！");

            var issueDto = new FWIssueDto
            {
                ReportPerson = viewModel.ReportPerson,
                Time = Convert.ToDateTime(viewModel.Time),
                IssueTypeId = int.Parse(viewModel.Type),
                WSId = viewModel.WSId
            };

            var _issueDto = _fwIssueService.Insert(issueDto);

            if (viewModel.PatrolObjectReportViewModels.Count > 0)
            {
                viewModel.PatrolObjectReportViewModels.ToList().ForEach(x =>
                {
                    var reportDto = new FWPatrolObjectReportDto
                    {
                        IssueId = _issueDto.Id,
                        ObjectId = int.Parse(x.ObjectId),
                        Result = int.Parse(x.Result),
                        TaskId = viewModel.WSId
                    };

                    var reportEntity = _fwPatrolObjectReportRepository.Insert(reportDto.ToModel(reportDto));

                    if (reportEntity == null)
                    {
                        throw new WapException(StateCode.CODE_ARGUMENT_NULL, "批量设施上报出错！");
                    }
                });
            }

            return _issueDto.Id;
        }

        /// <summary>
        /// 获取批量设施上报对象详情
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        public IEnumerable<BatchReportDetailsViewModel> GetIssueObjectsByIssueId(string issueId)
        {
            return _fwPatrolObjectReportRepository.GetIssueObjectsByIssueId(issueId);
        }

        public FWPatrolObjectReportDto Insert(FWPatrolObjectReportDto dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(FWPatrolObjectReportDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWPatrolObjectReportDto> Query()
        {
            throw new NotImplementedException();
        }
    }
}
