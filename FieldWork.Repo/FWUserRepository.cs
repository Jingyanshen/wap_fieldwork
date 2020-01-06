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
    /// 
    /// </summary>
    public class FWUserRepository : Repository<IFWUserStorage>, IFWUserRepository
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWUser CreateFWUser(FWUser entity)
        {
            return Storage.CreateFWUser(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWUser UpdateFWUser(int id, FWUser entity)
        {
            return Storage.UpdateFWUser(id, entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWUser(int id)
        {
            return Storage.DeleteFWUser(id);
        }

        /// <summary>
        /// 查询指定用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWUser GetFWUserById(int id)
        {
            return Storage.GetFWUserById(id);
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserAll()
        {
            return Storage.GetFWUserAll();
        }

        /// <summary>
        /// 根据网格编号获取用户
        /// </summary>
        /// <param name="gridId"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByGridId(int gridId)
        {
            return Storage.GetFWUserByGridId(gridId);
        }

        /// <summary>
        /// 根据组织编号获取用户
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByStationId(int stationId)
        {
            return Storage.GetFWUserByStationId(stationId);
        }

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByRoleAndOrgId(int roleId, int stationId)
        {
            return Storage.GetFWUserByRoleAndOrgId(roleId, stationId);
        }

        /// <summary>
        /// 获取指定网格下指定角色人员
        /// </summary>
        /// <param name="rolid"></param>
        /// <returns></returns>
        public IEnumerable<FWUser> GetFWUserByRoleAndGridId(int roleId, int gridId)
        {
            return Storage.GetFWUserByRoleAndGridId(roleId, gridId);
        }
    }
}
