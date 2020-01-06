using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    /// <summary>
    /// 巡查任务服务层接口
    /// </summary>
    public interface IFWPatrolTaskService
    {
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolTaskDto CreateFWPatrolTask(FWPatrolTaskDto entity);

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolTaskDto UpdateFWPatrolTaskById(String id, FWPatrolTaskDto entity);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWPatrolTaskById(String id);

        /// <summary>
        /// 获取全部模型
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskDto> GetFWPatrolTaskAll();

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWPatrolTaskDto GetFWPatrolTaskById(String id);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        PaginationDto<FWPatrolTaskDto> QueryFWPatrolTaskPage(FWPatrolTaskPageDto queryPageDto);

        /// <summary>
        /// 获取当前任务的必达点和必达点状态
        /// </summary>
        /// <returns></returns>
        PaginationDto<FWCKPointDto> GetFWCKPointDto(string id, FWCKPointPageDto queryDto);

        /// <summary>
        /// 结束巡查
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        bool EndPatrolTask(string id, string reason, DateTime dateTime);


        /// <summary>
        /// 获取巡查上报列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<FWIssueViewModel> GetIssuesByTaskId(string id);
        /// <summary>
        /// 获取当前任务的全部必达点和必达点状态
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWCKPointDto> GetFWCKPointDtoAll(string id);

        /// <summary>
        /// 获取人员巡查历史
        /// </summary>
        /// <param name="user"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="since"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolTaskDto> GetFWPatrolTaskHistory(string user, DateTime start, DateTime end, int count, int since);

        /// <summary>
        /// 获取指定巡查任务的结束状态
        /// </summary>
        /// <returns></returns>
        bool GetPatrolTaskState(string id);
    }
}
