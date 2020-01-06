using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess
{
    public interface IFWPatrolGISRelationStorage : IStorageBase<FWPatrolGISRelation>
    {
        /// <summary>
        /// Get FWPatrolGISRelations By PatrolType
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolGISRelation> GetFWPatrolGISRelationsByPatrolType(int PatrolType);
    }
}
