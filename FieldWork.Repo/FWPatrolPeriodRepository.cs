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
    /// /
    /// </summary>
    public class FWPatrolPeriodRepository : Repository<IFWPatrolPeriodStorage>, IFWPatrolPeriodRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolPeriod CreateFWPatrolPeriod(FWPatrolPeriod entity)
        {
            return Storage.CreateFWPatrolPeriod(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFWPatrolPeriod(int id)
        {
            return Storage.DeleteFWPatrolPeriod(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FWPatrolPeriod UpdateFWPatrolPeriodById(int id, FWPatrolPeriod entity)
        {
            return Storage.UpdateFWPatrolPeriodById(id, entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FWPatrolPeriod GetFWPatrolPeriodById(int id)
        {
            return Storage.GetFWPatrolPeriodById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolPeriod> GetFWPatrolPeriodAll()
        {
            return Storage.GetFWPatrolPeriodAll();
        }
    }
}
