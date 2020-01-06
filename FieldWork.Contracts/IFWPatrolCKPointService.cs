using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model.Dto;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWPatrolCKPointService
    {
        FWPatrolCKPointDto Insert(FWPatrolCKPointDto dto);

        bool Delete(int id);

        bool Update(FWPatrolCKPointDto dto);

        IEnumerable<FWPatrolCKPointDto> Query(int gridId, string name);

        /// <summary>
        /// 根据网格ID查询必达点
        /// </summary>
        /// <param name="GridId">网格ID</param>
        /// <returns></returns>
        IEnumerable<FWPatrolCKPointDto> GetPointByGridId(int GridId);
    }
}
