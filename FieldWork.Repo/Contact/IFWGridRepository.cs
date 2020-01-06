using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    /// <summary>
    /// 定义网格数据仓库接口
    /// </summary>
    public interface IFWGridRepository
    {
        /// <summary>
        /// 新增网格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWGrid CreateFWGrid(FWGrid entity);

        /// <summary>
        /// 根据编号更新网格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWGrid UpdateFWGridById(Int32 id, FWGrid entity);

        /// <summary>
        /// 根据编号删除网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWGridById(Int32 id);

        /// <summary>
        /// 根据编号获取网格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWGrid GetFWGridById(Int32 id);

        /// <summary>
        /// 获取全部网格
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWGrid> GetFWGridAll();

        /// <summary>
        /// 获取网格geoJson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetGeoJsonById(int id);

        /// <summary>
        /// 获取人员所在组织以及子组织网格
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWGrid> GetFWGridByUserId(int userid);

        bool updateGeo(string text, int id);
    }
}
