using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWConstructionSiteService
    {
        /// <summary>
        /// 新增工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWConstructionSiteDto CreateFWConstructionSite(FWConstructionSiteDto entity);

        /// <summary>
        /// 根据编号更新工地
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWConstructionSiteDto UpdateFWConstructionSite(int id, FWConstructionSiteDto entity);

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
        FWConstructionSiteDto GetFWConstructionSiteById(Int32 id);

        /// <summary>
        /// 获取全部工地
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWConstructionSiteDto> GetFWConstructionSites();
    }
}
