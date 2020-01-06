using SH3H.WAP.FieldWork.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWIssueService : IServiceBase<FWIssueDto>
    {
        IEnumerable<FWPatrolIssueRelationDto> GetPatrolIssueRelation();
    }
}
