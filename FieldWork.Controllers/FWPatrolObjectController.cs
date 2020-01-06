
using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SH3H.SDK.WebApi.Core.Models;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.Controllers
{
    /// <summary>
    /// 服务控制器
    /// </summary>
    [Resource("fwPatrolObjectServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolObjectController : BaseController<IFWPatrolObjectService>
    {
        /// <summary>
        /// 新增FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrol/object")]
        [ActionName("createFWPatrolObject")]
        public WapResponse<FWPatrolObjectDto> CreateFWPatrolObject([FromBody]FWPatrolObjectDto entity)
        {
            var result = Service.CreateFWPatrolObject(entity);
            return new WapResponse<FWPatrolObjectDto>(result);
        }

        /// <summary>
        /// 批量新增巡查对象
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrol/objects")]
        [ActionName("addFWPatrolObjects")]
        public WapCollection<FWPatrolObjectDto> AddFWPatrolObjects([FromBody]List<FWPatrolObjectDto> entitys)
        {
            var result = Service.AddFWPatrolObjects(entitys);
            return new WapCollection<FWPatrolObjectDto>(result);
        }

        /// <summary>
        /// 根据编号修改FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patrol/object/{id}")]
        [ActionName("updateFWPatrolObjectById")]
        public WapResponse<FWPatrolObjectDto> UpdateFWPatrolObjectById(Int32 id, [FromBody]FWPatrolObjectDto entity)
        {
            var result = Service.UpdateFWPatrolObjectById(id, entity);
            return new WapResponse<FWPatrolObjectDto>(result);
        }

        /// <summary>
        ///  根据编号删除FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("patrol/object/{id}")]
        [ActionName("deleteFWPatrolObject")]
        public WapBoolean DeleteFWPatrolObject(Int32 id)
        {
            var result = Service.DeleteFWPatrolObject(id);
            return new WapBoolean(result);
        }

        /// <summary>
        /// 获取所有FWPatrolObject模型实体对象
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/object")]
        [ActionName("getFWPatrolObjectAll")]
        public WapCollection<FWPatrolObjectDto> GetFWPatrolObjectAll()
        {
            var result = Service.GetFWPatrolObjectAll();
            return new WapCollection<FWPatrolObjectDto>(result);
        }

        /// <summary>
        /// 根据编号获取指定FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/object/{id}")]
        [ActionName("getFWPatrolObjectById")]
        public WapResponse<FWPatrolObjectDto> GetFWPatrolObjectById(Int32 id)
        {
            var result = Service.GetFWPatrolObjectById(id);
            return new WapResponse<FWPatrolObjectDto>(result);
        }

        /// <summary>
        /// 根据网格编号获取对应FWPatrolObject模型实体对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrol/objects/{gridid}")]
        [ActionName("GetFWPatrolObjectsByGridId")]
        public WapCollection<FWPatrolObjectDto> GetFWPatrolObjectByGridId(Int32 GridId)
        {
            var result = Service.GetFWPatrolObjectByGridId(GridId);
            return new WapCollection<FWPatrolObjectDto>(result);
        }

        /// <summary>
        /// 满足自定义周期设置的巡查对象修改服务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("patrolObject")]
        [ActionName("updateFWPatrolObjectBase")]
        public WapBoolean UpdateFWPatrolObjectBase([FromBody]FWPatrolObjectViewModel viewModel)
        {
            return new WapBoolean(Service.UpdateFWPatrolObjectBase(viewModel));
        }

        /// <summary>
        /// 满足 自定义周期设置、批量选择 的巡查对象新增服务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("patrolObject")]
        [ActionName("createFWPatrolObjectBase")]
        public WapCollection<FWPatrolObjectDto> CreateFWPatrolObjectBase([FromBody]FWPatrolObjectViewModel viewModel)
        {
            return new WapCollection<FWPatrolObjectDto>(Service.CreateFWPatrolObjectBase(viewModel));
        }

        /// <summary>
        /// 根据网格编号及巡查类型模糊搜索巡查对象
        /// </summary>
        /// <param name="GridId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrolObjects/{gridId}/{patrolType}")]
        [ActionName("searchFWPatrolObjects")]
        public WapCollection<FWPatrolObjectDto> SearchFWPatrolObjects(int gridId, int patrolType)
        {
            return new WapCollection<FWPatrolObjectDto>(Service.Search(gridId, patrolType));
        }

        /// <summary>
        /// 满足自定义周期设置的根据巡查对象Id获取单个实体服务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patrolObjects/{id}")]
        [ActionName("getFWPatrolObjectBaseById")]
        public WapResponse<FWPatrolObjectViewModel> GetFWPatrolObjectBaseById(int id)
        {
            return new WapResponse<FWPatrolObjectViewModel>(Service.GetFWPatrolObjectBaseById(id));
        }
    }
}
