using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWWapUserAndRoleDto
    {
        [DataMember(Name = "userKey")]
        public string UserKey { get; set; }

        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        [DataMember(Name = "jobNumber")]
        public string JobNumber { get; set; }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "domainAccount")]
        public string DomainAccount { get; set; }

        [DataMember(Name = "pyCode")]
        public string PyCode { get; set; }

        [DataMember(Name = "sortSn")]
        public int SortSn { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "cellphone")]
        public string Cellphone { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "idCard")]
        public string IdCard { get; set; }

        [DataMember(Name = "birthday")]
        public long Birthday { get; set; }

        [DataMember(Name = "sex")]
        public int Sex { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "postNo")]
        public string PostNo { get; set; }

        [DataMember(Name = "isFieldStaff")]
        public bool IsFieldStaff { get; set; }

        [DataMember(Name = "extend")]
        public string Extend { get; set; }

        [DataMember(Name = "fileHash")]
        public string FileHash { get; set; }

        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }

        [DataMember(Name = "roleKey")]
        public string RoleKey { get; set; }

        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }

        [DataMember(Name = "parentRoleKey")]
        public string ParentRoleKey { get; set; }


        [DataMember(Name = "organizationId")]
        public int OrganizationId { get; set; }


        [DataMember(Name = "organizationKey")]
        public string OrganizationKey { get; set; }


        [DataMember(Name = "organizationCode")]
        public string OrganizationCode { get; set; }


        [DataMember(Name = "organizationName")]
        public string OrganizationName { get; set; }
    }

}
