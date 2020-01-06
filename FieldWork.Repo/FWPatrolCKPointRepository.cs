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
    public class FWPatrolCKPointRepository : Repository<IFWPatrolCKPointStorage>, IFWPatrolCKPointRepository
    {

        public FWPatrolCKPoint Insert(FWPatrolCKPoint entity)
        {
            return Storage.Insert(entity);
        }

        public bool Delete(int id)
        {
            return Storage.Delete(id);
        }

        public bool Update(FWPatrolCKPoint entity)
        {
            return Storage.Update(entity);
        }

        public IEnumerable<FWPatrolCKPoint> Query(int gridId, string name)
        {
            return Storage.Query(gridId, name);
        }

        /// <summary>
        /// 根据网格ID查询必达点
        /// </summary>
        /// <param name="GridId">网格ID</param>
        /// <returns></returns>
        public IEnumerable<FWPatrolCKPoint> GetPointByGridId(int GridId)
        {
            return Storage.GetPointByGridId(GridId);
        }
    }
}
