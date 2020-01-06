using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.WAP.FieldWork.Model;

namespace SH3H.WAP.FieldWork.DataAccess.Repo.Contact
{
    public interface IAuthRepository
    {
        string GetPhoneByuserId(int userId);

        IEnumerable<FWGridDto> GetOrganization();
    }
}
