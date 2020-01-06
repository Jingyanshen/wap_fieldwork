using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFWWapUserAndRoleStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWWapUserAndRoleDto> GetFWWapUserAndRoleDtoAll(string rolestr = "");

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWWapUserAndRoleDto> GetFWPatrolUserRoleByUserId(int id, int type, int roleId = 0);
    }
}
