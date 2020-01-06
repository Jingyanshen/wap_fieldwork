using FieldWork.Host.Runtime.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Host.Runtime.Service
{
    public class ManagerService
    {
        private PatrolSummaryStorage _PatrolSummaryStorage;

        private FWUserStorage _FWUserStorage;
        public ManagerService()
        {
            _PatrolSummaryStorage = new PatrolSummaryStorage();
            _FWUserStorage = new FWUserStorage();
        }

        public IEnumerable<FWPatrolManageDto> Get(int userId, string param)
        {
            return _PatrolSummaryStorage.GetPatrolManage(userId, param);
        }

        public IEnumerable<FWUser> GetFWUserByRoleId(string roleIds)
        {
            return _FWUserStorage.GetFWUserByRoleId(roleIds);
        }

    }
}
