using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess
{
    /// <summary>
    /// 定义全要素设备数据操作接口
    /// </summary>
    public interface IFWQYSFacilityStorage
    {
        /// <summary>
        /// 根据用户编号获取绑定的全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        IEnumerable<FWQYSFacility> GetFWQYSFacilityById(int userId);

        /// <summary>
        /// 获取所有全要素设备
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<FWQYSFacility> GetFWQYSFacility();
    }
}
