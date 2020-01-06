using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFWPatrolPeriodService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FWPatrolPeriodDto CreateFWPatrolPeriod(FWPatrolPeriodDto entity);

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
        FWPatrolPeriodDto UpdateFWPatrolPeriodById(int id, FWPatrolPeriodDto entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FWPatrolPeriodDto GetFWPatrolPeriodById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolPeriodDto> GetFWPatrolPeriodAll();
    }
}
