using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWGridService
    {
        /// <summary>
        /// 新增网格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWGridDto CreateFWGrid(FWGridDto entity);

        /// <summary>
        /// 根据编号更新网格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWGridDto UpdateFWGridById(Int32 id, FWGridDto entity);

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
        FWGridDto GetFWGridById(Int32 id);

        /// <summary>
        /// 获取全部网格
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWGridDto> GetFWGridAll();

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
        FWGridBuildTreeDto GetFWGridByUserId(int userid);
        /// <summary>
        /// 根据当前登录用户组织获取其下网格信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWGridDto> GetFWGridsByOrgId(int orgId);

        bool updateGeo();
    }
}
