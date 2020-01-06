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
    public class FWConstructionSiteRepository : Repository<IFWConstructionSiteStorage>, IFWConstructionSiteRepository
    {
        /// <summary>
        /// 新增工地
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWConstructionSite CreateFWConstructionSite(FWConstructionSite entity)
        {
            return Storage.CreateFWConstructionSite(entity);
        }

        /// <summary>
        /// 根据编号更新工地
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWConstructionSite UpdateFWConstructionSite(int id, FWConstructionSite entity)
        {
            return Storage.UpdateFWConstructionSite(id, entity);
        }

        /// <summary>
        /// 根据编号删除工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWConstructionSiteById(int id)
        {
            return Storage.DeleteFWConstructionSiteById(id);
        }

        /// <summary>
        /// 根据编号获取工地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWConstructionSite GetFWConstructionSiteById(int id)
        {
            return Storage.GetFWConstructionSiteById(id);
        }

        /// <summary>
        /// 获取全部工地
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWConstructionSite> GetFWConstructionSites()
        {
            return Storage.GetFWConstructionSites();
        }
    }
}
