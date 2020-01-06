using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess
{
    /// <summary>
    /// /
    /// </summary>
    public interface IFWPatrolPeriodStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolPeriod CreateFWPatrolPeriod(FWPatrolPeriod entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteFWPatrolPeriod(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolPeriod UpdateFWPatrolPeriodById(int id, FWPatrolPeriod entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWPatrolPeriod GetFWPatrolPeriodById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolPeriod> GetFWPatrolPeriodAll();
    }
}
