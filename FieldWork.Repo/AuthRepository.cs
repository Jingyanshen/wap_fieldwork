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
    public class AuthRepository : Repository<IAuthStorage>, IAuthRepository
    {
        public string GetPhoneByuserId(int userId)
        {
            return Storage.GetPhoneByuserId(userId);
        }

        public IEnumerable<FWGridDto> GetOrganization()
        {
            return Storage.GetOrganization();
        }
    }
}
