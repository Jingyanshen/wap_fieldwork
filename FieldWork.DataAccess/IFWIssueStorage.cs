using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess
{
    public interface IFWIssueStorage : IStorageBase<FWIssue>
    {
        IEnumerable<FWPatrolIssueRelation> GetPatrolIssueRelation();
    }
}
