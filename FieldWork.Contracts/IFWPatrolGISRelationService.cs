using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model.Dto;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWPatrolGISRelationService : IServiceBase<FWPatrolGISRelationDto>
    {
        /// <summary>
        /// Get FWPatrolGISRelations By PatrolType
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolGISRelationDto> GetFWPatrolGISRelationsByPatrolType(int PatrolType);
    }
}
