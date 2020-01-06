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
    /// 
    /// </summary>
    public class FWWapUserAndRoleRepository : Repository<IFWWapUserAndRoleStorage>, IFWWapUserAndRoleRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetFWWapUserAndRoleDtoAll(string rolestr = "")
        {
            return Storage.GetFWWapUserAndRoleDtoAll(rolestr);
        }

        /// <summary>
        /// 获取巡查人员
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWWapUserAndRoleDto> GetFWPatrolUserRoleByUserId(int id, int type, int roleId = 0)
        {
            return Storage.GetFWPatrolUserRoleByUserId(id, type, roleId );
        }
    }
}
