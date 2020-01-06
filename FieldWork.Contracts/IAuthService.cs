using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IAuthService
    {
        /// <summary>
        /// 根据用户编号获取联系方式
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        string GetPhoneByuserId(int userId);

        IEnumerable<FWGridDto> GetOrganization();
    }
}
