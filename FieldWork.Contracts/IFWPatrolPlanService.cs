using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model.Dto;
using SH3H.WAP.FieldWork.Model.ViewModels;

namespace SH3H.WAP.FieldWork.Contracts
{
    public interface IFWPatrolPlanService
    {
        FWPatrolPlanDto Insert(FWPatrolPlanDto dto);

        bool ChangeStatus(string id, int status);

        bool Update(FWPatrolPlanDto dto);

        IEnumerable<FWPatrolPlanDto> QueryAll();

        IEnumerable<FWPatrolPlanDto> Search(FWPatrolPlanViewModel planViewModel);
    }
}
