using SH3H.SDK.Definition.Exceptions;
using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Share;
using SH3H.WAP.FieldWork.Share.FieldWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class FWWapUserAndRoleServiceImpl : BaseService, IFWWapUserAndRoleService
    {
        /// <summary>
        /// 
        /// </summary>
        public IFWWapUserAndRoleRepository _wapUserAndRoleRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wapUserAndRoleRepository"></param>
        public FWWapUserAndRoleServiceImpl(IFWWapUserAndRoleRepository wapUserAndRoleRepository)
        {
            _wapUserAndRoleRepository = wapUserAndRoleRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetFWWapUserAndRoleDtoAll(string rolestr = "")
        {
            return _wapUserAndRoleRepository.GetFWWapUserAndRoleDtoAll(rolestr);
        }


        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetFWPatrolUserRoleByUserId(int id, int type)
        {
            int roleId = 0;
            var roleIdStr = System.Configuration.ConfigurationSettings.AppSettings["WAP_PATROLSTAFF_ROLE"];
            int.TryParse(roleIdStr.ToString(), out roleId);
            if (roleId == 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "巡查人员角色配置错误！");
            if (type != (int)UserRoleTypeEnum.ByStationSearch && type != (int)UserRoleTypeEnum.ByUserSearch)
                throw new WapException(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "类型参数错误！");

            return _wapUserAndRoleRepository.GetFWPatrolUserRoleByUserId(id, type, roleId);
        }
    }
}
