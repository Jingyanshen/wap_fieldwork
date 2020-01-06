using SH3H.SDK.Share;
using SH3H.SDK.WebApi.Controllers;
using SH3H.SDK.WebApi.Core;
using SH3H.SDK.WebApi.Core.Models;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SH3H.WAP.FieldWork.Controllers
{

    /// <summary>
    /// WapUser服务控制器
    /// </summary>
    [Resource("fwWapUserAndRoleServiceRes")]
    [RoutePrefix(Consts.URL_PREFIX_WAP + "/grid")]
    public class FWWapUserAndRoleController : BaseController<IFWWapUserAndRoleService>
    {
        /// <summary>
        /// 获取当前登陆人下的巡查人员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fwPatrolUsers")]
        [ActionName("getFWPatrolUserRoleByUserId")]
        public WapCollection<FWWapUserAndRoleDto> GetFWPatrolUserRoleByUserId(int id, int type)
        {
            var result = Service.GetFWPatrolUserRoleByUserId(id, type);
            return new WapCollection<FWWapUserAndRoleDto>(result);
        }
    }
}
