using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess
{
    /// <summary>
    /// 必达点打卡数据操作模型接口定义
    /// </summary>
    public interface IFWPatrolTaskCKPointStorage
    {
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolTaskCKPoint CreateFWPatrolTaskCKPoint(FWPatrolTaskCKPoint entity);

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolTaskCKPoint UpdateFWPatrolTaskCKPointById(string tid, int ckpid, FWPatrolTaskCKPoint entity);

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
        IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointAll();

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        FWPatrolTaskCKPoint GetFWPatrolTaskCKPointByTidAndCkPId(string tid, int ckpid);

        /// <summary>
        /// 根据指定任务编号获取模型列表
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointByTid(string tid);

        /// <summary>
        /// 根据必达点编号获取模型列表
        /// </summary>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointByCKid(int ckpid);

        /// <summary>
        /// 获取模型分页列表
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        PaginationDto<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointPage(FWPatrolTaskCKPointPageDto queryPageDto);

        /// <summary>
        /// 必达点打卡
        /// </summary>
        /// <returns></returns>
        //bool UpdateFWPatrolTaskCheckIn(FWPatrolTaskCKPoint entity);

    }
}
