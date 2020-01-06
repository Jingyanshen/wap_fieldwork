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
    public class FWQYSFacilityService : BaseService, IFWQYSFacilityService
    {
        private IFWQYSFacilityRepository _qysfacilityRepository;

        public FWQYSFacilityService(IFWQYSFacilityRepository qysFacilityRepository)
        {
            _qysfacilityRepository = qysFacilityRepository;
        }

        /// <summary>
        /// 根据用户编号获取绑定的全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IEnumerable<FWQYSFacilityDto> GetFWQYSFacilityById(int userId)
        {
            return _qysfacilityRepository.GetFWQYSFacilityById(userId).Select(p => FWQYSFacilityDto.FromModel(p));
        }

        /// <summary>
        /// 获取所有全要素设备
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IEnumerable<FWQYSFacilityDto> GetFWQYSFacility()
        {
            return _qysfacilityRepository.GetFWQYSFacility().Select(p => FWQYSFacilityDto.FromModel(p));
        }
    }
}
