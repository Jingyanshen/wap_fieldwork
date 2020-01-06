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

namespace SH3H.WAP.FieldWork.Service
{
    public class FWIssueService : BaseService, IFWIssueService
    {
        private IFWIssueRepository _fwIssueRepository;
        public FWIssueService(IFWIssueRepository fwIssueRepository)
        {
            _fwIssueRepository = fwIssueRepository;
        }
        public FWIssueDto Insert(FWIssueDto dto)
        {
            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            var plan =
                Query()
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (plan == null)
            {
                dto.Id = "IS" + DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + "000001";
            }
            else
            {
                var maxId = Convert.ToInt64(plan.Id.Replace("IS", ""));
                dto.Id = "IS" + (++maxId).ToString();
            }

            return FWIssueDto.FromModel(_fwIssueRepository.Insert(dto.ToModel(dto)));
        }

        public bool Update(FWIssueDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWIssueDto> Query()
        {
            return _fwIssueRepository.Query().Select(x => FWIssueDto.FromModel(x));
        }

        public IEnumerable<FWPatrolIssueRelationDto> GetPatrolIssueRelation()
        {
            return _fwIssueRepository.GetPatrolIssueRelation().Select(x => FWPatrolIssueRelationDto.FromModel(x));
        }
    }
}
