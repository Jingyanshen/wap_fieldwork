using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{

    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWUserDto
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户组织编码
        /// </summary>
        [DataMember(Name = "stationId")]
        public int StationId { get; set; }

        /// <summary>
        /// 用户组织名称
        /// </summary>
        [DataMember(Name = "stationName")]
        public string StationName { get; set; }

        /// <summary>
        /// 用户激活状态
        /// </summary>
        [DataMember(Name = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// 用户所属网格
        /// </summary>
        [DataMember(Name = "gridId")]
        public int GridId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWUserDto FromModel(FWUser model)
        {
            if (model == null)
            {
                return null;
            }
            return new FWUserDto()
            {
                Active = model.Active,
                GridId = model.GridId,
                Id = model.Id,
                Name = model.Name,
                StationId = model.StationId,
                StationName = model.StationName,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FWUser ToModel()
        {
            return new FWUser()
            {
                Active = this.Active,
                GridId = this.GridId,
                Id = this.Id,
                Name = this.Name,
                StationId = this.StationId,
                StationName = this.StationName,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();

            if (string.IsNullOrWhiteSpace(this.Name))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "用户名称不能为空！");
            if (this.Name.Length > 50)
                result.AddError(StateCode.CODE_ARGUMENT_LENGTH, "用户名称不能超过50个字符！");
            if (this.StationId <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "用户组织编码不能为空！");
            if (string.IsNullOrWhiteSpace(this.StationName))
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "用户组织名称不能为空！");
            if (this.StationName.Length > 50)
                result.AddError(StateCode.CODE_ARGUMENT_LENGTH, "用户组织名字不能超过50个字符！");
            if (this.GridId <= 0)
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "用户的责任网格不能为空！");

            return result;
        }
    }
}
