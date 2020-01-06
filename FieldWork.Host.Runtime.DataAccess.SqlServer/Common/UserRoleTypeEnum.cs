using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
    /// <summary>
    /// 查询方式
    /// </summary>
    public enum UserRoleTypeEnum : int
    {
        /// <summary>
        /// 人员ID查询
        /// </summary>
        ByUserSearch = 1,
        /// <summary>
        /// 站点ID查询
        /// </summary>
        ByStationSearch = 2
    }
}
