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
    public class FWPatrolTaskCKPointImpl : BaseService, IFWPatrolTaskCKPointService
    {
        private IFWPatrolTaskCKPointRepository _patrolTaskCKPointRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patrolTaskCKPointRepository"></param>
        public FWPatrolTaskCKPointImpl(IFWPatrolTaskCKPointRepository patrolTaskCKPointRepository)
        {
            _patrolTaskCKPointRepository = patrolTaskCKPointRepository;
        }
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPointDto CreateFWPatrolTaskCKPoint(FWPatrolTaskCKPointDto entity)
        {
            var result = _patrolTaskCKPointRepository.CreateFWPatrolTaskCKPoint(entity.ToModel());
            return FWPatrolTaskCKPointDto.FromModel(result);
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPointDto UpdateFWPatrolTaskCKPointById(string tid, int ckpid, FWPatrolTaskCKPointDto entity)
        {
            var result = _patrolTaskCKPointRepository.UpdateFWPatrolTaskCKPointById(tid, ckpid, entity.ToModel());
            return FWPatrolTaskCKPointDto.FromModel(result);
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolTaskCKPointById(string tid, int ckpid)
        {
            return _patrolTaskCKPointRepository.DeleteFWPatrolTaskCKPointById(tid, ckpid);
        }

        /// <summary>
        /// 查询全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointAll()
        {
            var result = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointAll();

            return result.Select(p => FWPatrolTaskCKPointDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPointDto GetFWPatrolTaskCKPointByTidAndCkPId(string tid, int ckpid)
        {
            var result = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointByTidAndCkPId(tid, ckpid);
            return FWPatrolTaskCKPointDto.FromModel(result);
        }

        /// <summary>
        /// 根据指定任务编号获取模型列表
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByTid(string tid)
        {
            var result = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointByTid(tid);
            return result.Select(p => FWPatrolTaskCKPointDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 根据必达点编号获取模型列表
        /// </summary>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByCKid(int ckpid)
        {
            var result = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointByCKid(ckpid);
            return result.Select(p => FWPatrolTaskCKPointDto.FromModel(p)).ToList();
        }

        /// <summary>
        /// 获取模型分页列表
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        public PaginationDto<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointPage(FWPatrolTaskCKPointPageDto queryPageDto)
        {
            if (queryPageDto == null)
            {
                queryPageDto = new FWPatrolTaskCKPointPageDto();
            }
            var result = _patrolTaskCKPointRepository.GetFWPatrolTaskCKPointPage(queryPageDto);
            return new PaginationDto<FWPatrolTaskCKPointDto>()
            {
                DataList = result.DataList.Select(p => FWPatrolTaskCKPointDto.FromModel(p)).ToList(),
                TotalCount = result.TotalCount
            };
        }
    }
}
