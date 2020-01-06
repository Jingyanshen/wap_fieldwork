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
    public class FWPatrolObjectReportRepository : Repository<IFWPatrolObjectReportStorage>, IFWPatrolObjectReportRepository
    {
        public FWPatrolObjectReport Insert(FWPatrolObjectReport entity)
        {
            return Storage.Insert(entity);
        }

        public bool Update(FWPatrolObjectReport entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FWPatrolObjectReport> Query()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BatchReportDetailsViewModel> GetIssueObjectsByIssueId(string issueId)
        {
            return Storage.GetIssueObjectsByIssueId(issueId);
        }
    }
}
