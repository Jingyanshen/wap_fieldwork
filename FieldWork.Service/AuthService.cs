using SH3H.SDK.Service.Core;
using SH3H.WAP.FieldWork.Contracts;
using SH3H.WAP.FieldWork.Model;
using SH3H.WAP.FieldWork.DataAccess.Repo.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SH3H.SDK.Definition.Exceptions;
using SH3H.WAP.FieldWork.Share;

namespace SH3H.WAP.FieldWork.Service
{
    public class AuthService : BaseService, IAuthService
    {
        private IAuthRepository _authRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authRepository"></param>
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <summary>
        /// 根据用户编号获取联系方式
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public string GetPhoneByuserId(int userId)
        {
            if (userId < 0)
                throw new WapException(StateCode.CODE_ARGUMENT_NULL, "输入参数对象为空！");
            return _authRepository.GetPhoneByuserId(userId);
        }

        public IEnumerable<FWGridDto> GetOrganization()
        {
            return _authRepository.GetOrganization();
        }
    }
}
