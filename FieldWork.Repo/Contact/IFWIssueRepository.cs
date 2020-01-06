using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    public interface IFWIssueRepository : IRepositoryBase<FWIssue>
    {
        IEnumerable<FWPatrolIssueRelation> GetPatrolIssueRelation();
    }
}
