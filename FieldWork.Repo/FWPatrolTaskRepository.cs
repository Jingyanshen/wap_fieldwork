using SH3H.SDK.DataAccess.Repo;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo
{
    /// <summary>
    /// 巡查任务仓库实现
    /// </summary>
    public class FWPatrolTaskRepository : Repository<IFWPatrolTaskStorage>, IFWPatrolTaskRepository
    {
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTask CreateFWPatrolTask(FWPatrolTask entity)
        {
            return Storage.CreateFWPatrolTask(entity);
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTask UpdateFWPatrolTaskById(String id, FWPatrolTask entity)
        {
            return Storage.UpdateFWPatrolTaskById(id, entity);
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolTaskById(String id)
        {
            return Storage.DeleteFWPatrolTaskById(id);
        }

        /// <summary>
        /// 获取全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolTask> GetFWPatrolTaskAll()
        {
            return Storage.GetFWPatrolTaskAll();
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolTask GetFWPatrolTaskById(String id)
        {
            return Storage.GetFWPatrolTaskById(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        public PaginationDto<FWPatrolTask> QueryFWPatrolTaskPage(FWPatrolTaskPageDto queryPageDto)
        {
            return Storage.QueryFWPatrolTaskPage(queryPageDto);
        }

        /// <summary>
        /// 结束巡查
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool EndPatrolTask(string id, string reason, DateTime dateTime)
        {
            return Storage.EndPatrolTask(id, reason,dateTime);
        }


        /// <summary>
        /// 获取巡查上报列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<FWIssueViewModel> GetIssuesByTaskId(string id)
        {
            return Storage.GetIssuesByTaskId(id);
        }
        /// <summary>
        /// 获取人员巡查历史
        /// </summary>
        /// <param name="user"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="since"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTask> GetFWPatrolTaskHistory(string user, DateTime start, DateTime end, int count, int since)
        {
            return Storage.GetFWPatrolTaskHistory(user, start, end, count, since);
        }

        /// <summary>
        /// 获取指定巡查任务的结束状态
        /// </summary>
        /// <returns></returns>
        public bool GetPatrolTaskState(string id)
        {
            return Storage.GetPatrolTaskState(id);
        }
    }
}
