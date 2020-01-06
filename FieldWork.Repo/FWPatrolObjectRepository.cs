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
    /// <summary>
    /// 定义FWPatrolObject模型数据仓库接口实现层
    /// </summary>
    public class FWPatrolObjectRepository : Repository<IFWPatrolObjectStorage>, IFWPatrolObjectRepository
    {
        public FWPatrolObjectRepository() { }
        /// <summary>
        /// 新增FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolObject CreateFWPatrolObject(FWPatrolObject entity)
        {
            return Storage.CreateFWPatrolObject(entity);
        }

        /// <summary>
        /// 修改FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolObject UpdateFWPatrolObjectById(Int32 id, FWPatrolObject entity)
        {
            return Storage.UpdateFWPatrolObjectById(id, entity);
        }

        /// <summary>
        /// 删除FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolObject(Int32 id)
        {
            return Storage.DeleteFWPatrolObject(id);
        }

        /// <summary>
        /// 获取所有FWPatrolObject模型实体对象
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolObject> GetFWPatrolObjectAll()
        {
            return Storage.GetFWPatrolObjectAll();
        }

        /// <summary>
        /// 获取指定FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolObject GetFWPatrolObjectById(Int32 id)
        {
            return Storage.GetFWPatrolObjectById(id);
        }

        /// <summary>
        /// 根据网格编号获取对应FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObject> GetFWPatrolObjectByGridId(Int32 GridId)
        {
            return Storage.GetFWPatrolObjectByGridId(GridId);
        }

        /// <summary>
        /// 根据网格编号及巡查类型获取对应巡查对象
        /// </summary>
        /// <param name="GridId">网格编号</param>
        /// <param name="Type">巡查类型</param>
        /// <returns></returns>
        public IEnumerable<FWPatrolObject> GetFWPatrolObjectByGridIdAndType(Int32 GridId, Int32 Type)
        {
            return Storage.GetFWPatrolObjectByGridIdAndType(GridId, Type);
        }
    }
}
