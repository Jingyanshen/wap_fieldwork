using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFWWapUserAndRoleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWWapUserAndRoleDto> GetFWWapUserAndRoleDtoAll(string rolestr = "");

        /// <summary>
        /// 获取人员
        /// 当前人员所在组织（包含当前组织）下的所有值请角色人员
        /// 如果当前人员属于“所”下面的级别那么则返回当前“所”下的人员
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWWapUserAndRoleDto> GetFWPatrolUserRoleByUserId(int id, int type);
    }
}
