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
    /// 定义网格数据仓库接口实现层
    /// </summary>
    public class FWGridRepository : Repository<IFWGridStorage>, IFWGridRepository
    {
        public FWGridRepository()
        {
        }

        /// <summary>
        /// 新增网格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWGrid CreateFWGrid(FWGrid entity)
        {
            return Storage.CreateFWGrid(entity);
        }

        /// <summary>
        /// 根据编号更新网格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWGrid UpdateFWGridById(Int32 id, FWGrid entity)
        {
            return Storage.UpdateFWGridById(id, entity);
        }

        /// <summary>
        /// 根据编号删除网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWGridById(Int32 id)
        {
            return Storage.DeleteFWGridById(id);
        }

        /// <summary>
        /// 根据编号获取网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWGrid GetFWGridById(Int32 id)
        {
            return Storage.GetFWGridById(id);
        }

        /// <summary>
        /// 获取全部网格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGrid> GetFWGridAll()
        {
            return Storage.GetFWGridAll();
        }

        /// <summary>
        /// 获取网格geoJson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetGeoJsonById(int id)
        {
            return Storage.GetGeoJsonById(id);
        }

        /// <summary>
        /// 获取人员所在组织以及子组织网格
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWGrid> GetFWGridByUserId(int userid)
        {
            return Storage.GetFWGridByUserId(userid);
        }

        public bool updateGeo(string text, int id)
        {
            return Storage.updateGeo(text ,id);
        }
    }
}
