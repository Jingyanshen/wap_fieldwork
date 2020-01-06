using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.DataAccess.SqlServer
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    public class FWUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户组织编码
        /// </summary>
        public int StationId { get; set; }

        /// <summary>
        /// 用户组织名称
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 用户激活状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 用户所属网格
        /// </summary>
        public int GridId { get; set; }
    }
}
