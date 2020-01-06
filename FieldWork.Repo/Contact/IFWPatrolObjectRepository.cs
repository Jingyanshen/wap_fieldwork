using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    /// <summary>
    /// 定义FWPatrolObject模型数据仓库接口
    /// </summary>
    public interface IFWPatrolObjectRepository
    {
        /// <summary>
        /// 新增FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolObject CreateFWPatrolObject(FWPatrolObject entity);

        /// <summary>
        /// 修改FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolObject UpdateFWPatrolObjectById(Int32 id, FWPatrolObject entity);

        /// <summary>
        /// 删除FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWPatrolObject(Int32 id);

        /// <summary>
        /// 获取所有FWPatrolObject模型实体对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolObject> GetFWPatrolObjectAll();

        /// <summary>
        /// 获取指定FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWPatrolObject GetFWPatrolObjectById(Int32 id);

        /// <summary>
        /// 根据网格编号获取对应FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolObject> GetFWPatrolObjectByGridId(Int32 GridId);

        /// <summary>
        /// 根据网格编号及巡查类型获取对应巡查对象
        /// </summary>
        /// <param name="GridId">网格编号</param>
        /// <param name="Type">巡查类型</param>
        /// <returns></returns>
        IEnumerable<FWPatrolObject> GetFWPatrolObjectByGridIdAndType(Int32 GridId , Int32 Type);
    }
}
