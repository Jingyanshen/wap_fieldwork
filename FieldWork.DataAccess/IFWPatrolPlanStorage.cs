using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.DataAccess
{
    public interface IFWPatrolPlanStorage
    {
        FWPatrolPlan Insert(FWPatrolPlan entity);

        bool ChangeStatus(string id, int status);

        bool Update(FWPatrolPlan entity, string content);

        IEnumerable<FWPatrolPlan> QueryAll();

        IEnumerable<FWPatrolPlan> Search(FWPatrolPlanViewModel planViewModel);
    }
}
