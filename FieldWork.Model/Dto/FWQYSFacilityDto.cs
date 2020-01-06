using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    /// <summary>
    /// 全要素设备详情
    /// </summary>
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWQYSFacilityDto
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember(Name = "facilityId")]
        public string FacilityId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [DataMember(Name = "facilityName")]
        public string FacilityName { get; set; }

        /// <summary>
        /// 绑定用户ID
        /// </summary>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// 绑定用户账号
        /// </summary>
        [DataMember(Name = "userAccount")]
        public string UserAccount { get; set; }

        /// <summary>
        /// 绑定用户名称
        /// </summary>
        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户绑定类型(1:联系人,2:责任人)
        /// </summary>
        [DataMember(Name = "type")]
        public int Type { get; set; }

        /// <summary>
        /// QYSFacility模型转QYSFacilityDto对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWQYSFacilityDto FromModel(FWQYSFacility model)
        {
            if (model == null)
            {
                return null;
            }
            FWQYSFacilityDto dto = new FWQYSFacilityDto()
            {
                FacilityId = model.FacilityId,
                FacilityName = model.FacilityName,
                UserId = model.UserId,
                UserAccount = model.UserAccount,
                UserName = model.UserName,
                Type = model.Type
            };
            return dto;
        }

        /// <summary>
        /// QYSFacilityDto对象转QYSFacility模型
        /// </summary>
        /// <returns></returns>
        public FWQYSFacility ToModel()
        {
            FWQYSFacility model = new FWQYSFacility()
            {
                FacilityId = this.FacilityId,
                FacilityName = this.FacilityName,
                UserAccount = this.UserAccount,
                UserId = this.UserId,
                UserName = this.UserName,
                Type = this.Type
            };

            return model;
        }
    }
}
