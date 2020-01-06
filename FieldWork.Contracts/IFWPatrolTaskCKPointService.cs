using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFWPatrolTaskCKPointService
    {
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolTaskCKPointDto CreateFWPatrolTaskCKPoint(FWPatrolTaskCKPointDto entity);

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolTaskCKPointDto UpdateFWPatrolTaskCKPointById(string tid, int ckpid, FWPatrolTaskCKPointDto entity);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        bool DeleteFWPatrolTaskCKPointById(string tid, int ckpid);

        /// <summary>
        /// 查询全部模型
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointAll();

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        FWPatrolTaskCKPointDto GetFWPatrolTaskCKPointByTidAndCkPId(string tid, int ckpid);

        /// <summary>
        /// 根据指定任务编号获取模型列表
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByTid(string tid);

        /// <summary>
        /// 根据必达点编号获取模型列表
        /// </summary>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointByCKid(int ckpid);

        /// <summary>
        /// 获取模型分页列表
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        PaginationDto<FWPatrolTaskCKPointDto> GetFWPatrolTaskCKPointPage(FWPatrolTaskCKPointPageDto queryPageDto);
    }
}
