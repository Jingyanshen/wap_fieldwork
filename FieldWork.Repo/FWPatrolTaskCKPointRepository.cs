using SH3H.SDK.DataAccess.Repo;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo
{
    public class FWPatrolTaskCKPointRepository : Repository<IFWPatrolTaskCKPointStorage>, IFWPatrolTaskCKPointRepository
    {
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPoint CreateFWPatrolTaskCKPoint(FWPatrolTaskCKPoint entity)
        {
            return Storage.CreateFWPatrolTaskCKPoint(entity);
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPoint UpdateFWPatrolTaskCKPointById(string tid, int ckpid, FWPatrolTaskCKPoint entity)
        {
            return Storage.UpdateFWPatrolTaskCKPointById(tid, ckpid, entity);
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolTaskCKPointById(string tid, int ckpid)
        {
            return Storage.DeleteFWPatrolTaskCKPointById(tid, ckpid);
        }

        /// <summary>
        /// 查询全部模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointAll()
        {
            return Storage.GetFWPatrolTaskCKPointAll();
        }

        /// <summary>
        /// 获取指定模型
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public FWPatrolTaskCKPoint GetFWPatrolTaskCKPointByTidAndCkPId(string tid, int ckpid)
        {
            return Storage.GetFWPatrolTaskCKPointByTidAndCkPId(tid, ckpid);
        }

        /// <summary>
        /// 根据指定任务编号获取模型列表
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointByTid(string tid)
        {
            return Storage.GetFWPatrolTaskCKPointByTid(tid);
        }

        /// <summary>
        /// 根据必达点编号获取模型列表
        /// </summary>
        /// <param name="ckpid"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointByCKid(int ckpid)
        {
            return Storage.GetFWPatrolTaskCKPointByCKid(ckpid);
        }

        /// <summary>
        /// 获取模型分页列表
        /// </summary>
        /// <param name="queryPageDto"></param>
        /// <returns></returns>
        public PaginationDto<FWPatrolTaskCKPoint> GetFWPatrolTaskCKPointPage(FWPatrolTaskCKPointPageDto queryPageDto)
        {
            return Storage.GetFWPatrolTaskCKPointPage(queryPageDto);
        }
    }
}
