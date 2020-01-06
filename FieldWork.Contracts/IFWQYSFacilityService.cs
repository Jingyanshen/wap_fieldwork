using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWQYSFacilityService
    {
        /// <summary>
        /// 根据用户编号获取绑定的全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        IEnumerable<FWQYSFacilityDto> GetFWQYSFacilityById(int userId);

        /// <summary>
        /// 获取所有全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        IEnumerable<FWQYSFacilityDto> GetFWQYSFacility();
    }
}
