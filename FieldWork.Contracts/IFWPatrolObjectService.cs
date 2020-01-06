using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWPatrolObjectService
    {
        /// <summary>
        /// 新增FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolObjectDto CreateFWPatrolObject(FWPatrolObjectDto entity);

        /// <summary>
        /// 批量新增巡查对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolObjectDto> AddFWPatrolObjects(List<FWPatrolObjectDto> entitys);

        /// <summary>
        /// 根据编号修改FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolObjectDto UpdateFWPatrolObjectById(Int32 id, FWPatrolObjectDto entity);

        /// <summary>
        /// 根据编号删除FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWPatrolObject(Int32 id);

        /// <summary>
        /// 获取所有FWPatrolObject模型实体对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolObjectDto> GetFWPatrolObjectAll();

        /// <summary>
        /// 根据编号获取指定FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWPatrolObjectDto GetFWPatrolObjectById(Int32 id);

        /// <summary>
        /// 根据网格编号获取对应FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolObjectDto> GetFWPatrolObjectByGridId(Int32 GridId);

        /// <summary>
        /// 根据网格编号及巡查类型获取对应巡查对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolObjectDto> GetFWPatrolObjectByGridIdAndType(Int32 GridId, Int32 Type);

        /// <summary>
        /// 满足自定义周期设置的巡查对象新增方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolObjectDto> CreateFWPatrolObjectBase(FWPatrolObjectViewModel viewModel);

        /// <summary>
        /// 满足自定义周期设置的巡查对象修改方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateFWPatrolObjectBase(FWPatrolObjectViewModel viewModel);

        /// <summary>
        /// 满足自定义周期设置的根据巡查对象Id获取单个实体
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        FWPatrolObjectViewModel GetFWPatrolObjectBaseById(int id);

        /// <summary>
        /// 根据网格编号及巡查类型模糊搜索巡查对象
        /// </summary>
        /// <param name="gridId"></param>
        /// <param name="patrolType"></param>
        /// <returns></returns>
        IEnumerable<FWPatrolObjectDto> Search(int gridId, int patrolType);
    }
}
