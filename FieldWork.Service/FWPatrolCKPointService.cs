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
    public class FWPatrolCKPointService : BaseService, IFWPatrolCKPointService
    {
        private IFWPatrolCKPointRepository _patrolCKPointRepository;
        private IFWPatrolPeriodRepository _patrolPeriodRepository;
        public FWPatrolCKPointService(IFWPatrolCKPointRepository patrolCKPointRepository, IFWPatrolPeriodRepository patrolPeriodRepository)
        {
            _patrolCKPointRepository = patrolCKPointRepository;
            _patrolPeriodRepository = patrolPeriodRepository;
        }

        public FWPatrolCKPointDto Insert(FWPatrolCKPointDto dto)
        {
            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            dto.PeriodId = DefineCustomizePeriod(dto);

            return FWPatrolCKPointDto.FromModel(_patrolCKPointRepository.Insert(dto.ToModel(dto)));
        }

        public bool Delete(int id)
        {
            return _patrolCKPointRepository.Delete(id);
        }

        public bool Update(FWPatrolCKPointDto dto)
        {
            if (dto == null)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");

            var target = _patrolPeriodRepository.GetFWPatrolPeriodById(dto.PatrolPeriodId);

            if (target != null)
            {
                _patrolPeriodRepository.DeleteFWPatrolPeriod(target.PeriodId);
                dto.PeriodId = 0;
            }

            dto.PeriodId = DefineCustomizePeriod(dto);

            return _patrolCKPointRepository.Update(dto.ToModel(dto));
        }

        public IEnumerable<FWPatrolCKPointDto> Query(int gridId, string name)
        {
            var entities = _patrolCKPointRepository.Query(gridId, name);
            foreach (var entity in entities)
            {
                yield return FWPatrolCKPointDto.FromModel(entity);
            }
        }

        /// <summary>
        /// 根据网格ID查询必达点
        /// </summary>
        /// <param name="GridId">网格ID</param>
        /// <returns></returns>
        public IEnumerable<FWPatrolCKPointDto> GetPointByGridId(int GridId)
        {
            var entities = _patrolCKPointRepository.GetPointByGridId(GridId);
            foreach (var entity in entities)
            {
                yield return FWPatrolCKPointDto.FromModel(entity);
            }
        }

        private int DefineCustomizePeriod(FWPatrolCKPointDto dto)
        {
            if (dto.Period.Equals("customize", StringComparison.InvariantCultureIgnoreCase))
            {
                var patrolPeriod = new FWPatrolPeriodDto
                {
                    PeriodId = dto.PatrolPeriodId,
                    PeriodBase = dto.PeriodBase,
                    Interval = dto.Interval
                };

                var _patrolPeriod = _patrolPeriodRepository.CreateFWPatrolPeriod(patrolPeriod.ToModel());

                return _patrolPeriod == null ? 0 : _patrolPeriod.PeriodId;
            }
            return dto.PeriodId;
        }
    }
}
