using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class FWPatrolPeriodServiceImpl : BaseService, IFWPatrolPeriodService
    {

        private IFWPatrolPeriodRepository _patrolPeriodRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patrolPeriodRepository"></param>
        public FWPatrolPeriodServiceImpl(IFWPatrolPeriodRepository patrolPeriodRepository)
        {
            _patrolPeriodRepository = patrolPeriodRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolPeriodDto CreateFWPatrolPeriod(FWPatrolPeriodDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查周期模型为空！");
            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();
            return FWPatrolPeriodDto.FromModel(_patrolPeriodRepository.CreateFWPatrolPeriod(entity.ToModel()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolPeriod(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查周期编码为空！");
            return _patrolPeriodRepository.DeleteFWPatrolPeriod(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolPeriodDto UpdateFWPatrolPeriodById(int id, FWPatrolPeriodDto entity)
        {
            if (entity == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查周期模型为空！");
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查周期编码为空！");
            if (id != entity.PeriodId)
                throw new WapException(StateCode.CODE_ARGUMENT_NOT_EQUAL, "巡查周期编码参数不一致！");
            var result = entity.Validate();
            if (!result.IsValid) throw result.BuildException();
            return FWPatrolPeriodDto.FromModel(_patrolPeriodRepository.UpdateFWPatrolPeriodById(id, entity.ToModel()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolPeriodDto GetFWPatrolPeriodById(int id)
        {
            if (id <= 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查周期编码为空！");
            var result = _patrolPeriodRepository.GetFWPatrolPeriodById(id);
            return FWPatrolPeriodDto.FromModel(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolPeriodDto> GetFWPatrolPeriodAll()
        {
            var result = _patrolPeriodRepository.GetFWPatrolPeriodAll();
            return result.Select(p => FWPatrolPeriodDto.FromModel(p)).ToList();
        }
    }
}
