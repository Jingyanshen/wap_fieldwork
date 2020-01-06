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
    /// 全要素设备数据仓库接口
    /// </summary>
    public class FWQYSFacilityRepository : Repository<IFWQYSFacilityStorage>, IFWQYSFacilityRepository
    {
        public FWQYSFacilityRepository()
        {
        }
        /// <summary>
        /// 根据用户编号获取绑定的全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IEnumerable<FWQYSFacility> GetFWQYSFacilityById(int userId)
        {
            return Storage.GetFWQYSFacilityById(userId);
        }

        /// <summary>
        /// 获取所有全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IEnumerable<FWQYSFacility> GetFWQYSFacility()
        {
            return Storage.GetFWQYSFacility();
        }

    }
}
