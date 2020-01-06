using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer.IStorage
{
    public interface IFWUserStorage
    {
        /// <summary>
        /// 获取指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        IEnumerable<FWUser> GetFWUserByRoleId(string roleId);
    }
}
