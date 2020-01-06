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
using SH3H.WAP.WorkSheet.Contracts;


namespace SH3H.WAP.FieldWork.Service
{
    public class FWPatrolPlanService : BaseService, IFWPatrolPlanService
    {
        private IFWPatrolPlanRepository _patrolPlanRepository;
        private IWSSeqService _wsSeqService;
        public FWPatrolPlanService(IFWPatrolPlanRepository patrolPlanRepository, IWSSeqService wsSeqService)
        {
            _patrolPlanRepository = patrolPlanRepository;
            _wsSeqService = wsSeqService;
        }

        public FWPatrolPlanDto Insert(FWPatrolPlanDto dto)
        {
            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            dto.Id = _wsSeqService.GetSeq("PL");

            if (string.IsNullOrWhiteSpace(dto.Id))
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查计划编号为空！");
            if (dto.Id.Length > 20)
                throw new WapException(StateCode.CODE_ARGUMENT_LENGTH, "巡查计划编号字符长度大于20！");


            var target = _patrolPlanRepository.Insert(dto.ToModel(dto));

            return FWPatrolPlanDto.FromModel(target);
        }

        public bool ChangeStatus(string id, int status)
        {
            return _patrolPlanRepository.ChangeStatus(id, status);
        }

        public bool Update(FWPatrolPlanDto dto)
        {
            // Unchanged
            var plan = QueryAll().FirstOrDefault(p => p.Id == dto.Id);

            var props = plan.GetType().GetProperties();

            // Changed
            var _props = dto.GetType().GetProperties();

            var content = "";

            foreach (var prop in props)
            {
                foreach (var _prop in _props)
                {
                    if (prop.Name.Equals(_prop.Name))
                    {
                        var propValue = prop.GetValue(plan).ToString();

                        var _propValue = _prop.GetValue(dto).ToString();

                        if (propValue != _propValue)
                        {
                            content += string.Format("{0}的值已由原先的{1}改变为{2}，", _prop.Name, propValue, _propValue);
                        }

                        break;
                    }
                }
            }

            return _patrolPlanRepository.Update(dto.ToModel(dto), content.Substring(0, content.Length - 1));
        }

        public IEnumerable<FWPatrolPlanDto> QueryAll()
        {
            return _patrolPlanRepository.QueryAll().Select(x => FWPatrolPlanDto.FromModel(x));
        }

        public IEnumerable<FWPatrolPlanDto> Search(FWPatrolPlanViewModel planViewModel)
        {
            return _patrolPlanRepository.Search(planViewModel).Select(x => FWPatrolPlanDto.FromModel(x));
        }
    }
}
