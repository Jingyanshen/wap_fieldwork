using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    public interface IFWConstructionSiteRepository
    {
        /// <summary>
        /// 新增工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWConstructionSite CreateFWConstructionSite(FWConstructionSite entity);

        /// <summary>
        /// 根据编号更新工地
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWConstructionSite UpdateFWConstructionSite(int id, FWConstructionSite entity);

        /// <summary>
        /// 根据编号删除工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWConstructionSiteById(int id);

        /// <summary>
        /// 根据编号获取工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWConstructionSite GetFWConstructionSiteById(int id);

        /// <summary>
        /// 获取全部工地
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWConstructionSite> GetFWConstructionSites();
    }
}
