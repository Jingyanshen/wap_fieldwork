using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldWork.Outgoing.Model
{
    public class MCResult<T>
    {
        public int code { get; set; }
        public int statusCode { get; set; }

        public string message { get; set; }

        public T data { get; set; }
    }
    public class WSPlatformUserOut
    {
        public WSPlatformUserOut()
        {
            roles = new List<Roles>();
            organization = new Organization();
        }
        public string userKey { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public string jobNumber { get; set; }
        public string account { get; set; }
        public string domainAccount { get; set; }
        public string pyCode { get; set; }
        public int sortSn { get; set; }
        public bool active { get; set; }
        public string comment { get; set; }
        public string phone { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public string idCard { get; set; }
        public long birthday { get; set; }
        public int sex { get; set; }
        public string address { get; set; }
        public string postNo { get; set; }
        public bool isFieldStaff { get; set; }
        public string extend { get; set; }
        public string fileHash { get; set; }
        public Organization organization { get; set; }
        public List<Roles> roles { get; set; }
    }
    public class Organization
    {
        public int organizationId { get; set; }
        public string organizationKey { get; set; }
        public string organizationCode { get; set; }
        public string organizationName { get; set; }
    }
    public class Roles
    {
        public int roleId { get; set; }
        public string roleKey { get; set; }
        public string roleName { get; set; }
        public string parentRoleKey { get; set; }
    }
}
