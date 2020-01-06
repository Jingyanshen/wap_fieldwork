using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class WapCommon
    {
        /// <summary>
        /// 根据组织编码获取组织下人员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<WSPlatformUserOut> GetWapUsersByOrganId(int id)
        {
            var users = ServiceHelper.Get<string, MCResult<List<WSPlatformUserOut>>>(string.Format(OutgoingConsts.PlatPath + OutgoingConsts.WapUserInfoByOrgId, id), null);
            if (users != null && users.data != null && users.data.Count > 0)
            {
                return users.data;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<WSPlatformUserOut> GetWapUserAll()
        {
            var users = ServiceHelper.Get<string, MCResult<List<WSPlatformUserOut>>>(OutgoingConsts.PlatPath + OutgoingConsts.WapUserAll, null);
            if (users != null && users.data != null && users.data.Count > 0)
            {
                return users.data;
            }
            return null;
        }
    }
}
