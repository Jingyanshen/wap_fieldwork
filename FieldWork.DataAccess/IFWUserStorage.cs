using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess
{
    /// <summary>
    /// 用户数据操作接口
    /// </summary>
    public interface IFWUserStorage
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWUser CreateFWUser(FWUser entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWUser UpdateFWUser(int id, FWUser entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWUser(int id);

        /// <summary>
        /// 查询指定用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWUser GetFWUserById(int id);

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWUser> GetFWUserAll();

        /// <summary>
        /// 根据网格编号获取用户
        /// </summary>
        /// <param name="gridId"></param>
        /// <returns></returns>
        IEnumerable<FWUser> GetFWUserByGridId(int gridId);

        /// <summary>
        /// 根据组织编号获取用户
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        IEnumerable<FWUser> GetFWUserByStationId(int stationId);

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        IEnumerable<FWUser> GetFWUserByRoleAndOrgId(int roleId, int stationId);

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        IEnumerable<FWUser> GetFWUserByRoleAndGridId(int roleId, int gridId);
    }
}
