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
    public class FWPatrolPlanRepository : Repository<IFWPatrolPlanStorage>, IFWPatrolPlanRepository
    {
        public FWPatrolPlan Insert(FWPatrolPlan entity)
        {
            return Storage.Insert(entity);
        }

        public bool ChangeStatus(string id, int status)
        {
            return Storage.ChangeStatus(id, status);
        }

        public bool Update(FWPatrolPlan entity, string content)
        {
            return Storage.Update(entity, content);
        }

        public IEnumerable<FWPatrolPlan> QueryAll()
        {
            return Storage.QueryAll();
        }


        public IEnumerable<FWPatrolPlan> Search(FWPatrolPlanViewModel planViewModel)
        {
            return Storage.Search(planViewModel);
        }
    }
}
