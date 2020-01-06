using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess
{
    public interface IFWPatrolCKPointStorage
    {
        FWPatrolCKPoint Insert(FWPatrolCKPoint entity);

        bool Delete(int id);

        bool Update(FWPatrolCKPoint entity);

        IEnumerable<FWPatrolCKPoint> Query(int gridId, string name);

        /// <summary>
        /// 根据网格ID查询必达点
        /// </summary>
        /// <param name="GridId">网格ID</param>
        /// <returns></returns>
        IEnumerable<FWPatrolCKPoint> GetPointByGridId(int GridId);
    }
}
