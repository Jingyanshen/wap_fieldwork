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
    public class FWIssueRepository : Repository<IFWIssueStorage>, IFWIssueRepository
    {
        public FWIssue Insert(FWIssue entity)
        {
            return Storage.Insert(entity);
        }

        public bool Update(FWIssue entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWIssue> Query()
        {
            return Storage.Query();
        }

        public IEnumerable<FWPatrolIssueRelation> GetPatrolIssueRelation()
        {
            return Storage.GetPatrolIssueRelation();
        }
    }
}
