using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    public interface IFWPatrolGISRelationRepository : IRepositoryBase<FWPatrolGISRelation>
    {
        /// <summary>
        /// Get FWPatrolGISRelations By PatrolType
        /// </summary>
        /// <returns></returns>
        IEnumerable<FWPatrolGISRelation> GetFWPatrolGISRelationsByPatrolType(int PatrolType);
    }
}
