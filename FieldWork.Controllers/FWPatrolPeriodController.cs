using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.SDK.WebApi.Core.Models;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SH3H.WAP.FieldWork.Controllers
{
    /// <summary>
    /// 巡查周期服务控制器
    /// </summary>
    [Resource("fwPatrolPeriodServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP)]
    public class FWPatrolPeriodController : BaseController<IFWPatrolPeriodService>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public WapResponse<FWPatrolPeriodDto> CreateFWPatrolPeriod(FWPatrolPeriodDto entity)
        {
            var result = Service.CreateFWPatrolPeriod(entity);
            return new WapResponse<FWPatrolPeriodDto>(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WapBoolean DeleteFWPatrolPeriod(int id)
        {
            return new WapBoolean(Service.DeleteFWPatrolPeriod(id));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public WapResponse<FWPatrolPeriodDto> UpdateFWPatrolPeriodById(int id, FWPatrolPeriodDto entity)
        {
            var result = Service.UpdateFWPatrolPeriodById(id, entity);
            return new WapResponse<FWPatrolPeriodDto>(result);
        }

        /// <summary>
        /// 根据编号获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WapResponse<FWPatrolPeriodDto> GetFWPatrolPeriodById(int id)
        {
            var result = Service.GetFWPatrolPeriodById(id);
            return new WapResponse<FWPatrolPeriodDto>(result);
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fwPatrolPeriods")]
        [ActionName("getPatrolPeriods")]
        public WapCollection<FWPatrolPeriodDto> GetFWPatrolPeriodAll()
        {
            var result = Service.GetFWPatrolPeriodAll();
            return new WapCollection<FWPatrolPeriodDto>(result);
        }
    }
}
