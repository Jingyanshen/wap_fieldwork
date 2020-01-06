using SH3H.SDK.DataAccess.Repo;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo
{
    public class FWPatrolGISRelationRepository : Repository<IFWPatrolGISRelationStorage>, IFWPatrolGISRelationRepository
    {
        public FWPatrolGISRelation Insert(FWPatrolGISRelation entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(FWPatrolGISRelation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWPatrolGISRelation> Query()
        {
            return Storage.Query();
        }

        /// <summary>
        /// Get FWPatrolGISRelations By PatrolType
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FWPatrolGISRelation> GetFWPatrolGISRelationsByPatrolType(int PatrolType)
        {
            return Storage.GetFWPatrolGISRelationsByPatrolType(PatrolType);
        }
    }
}
