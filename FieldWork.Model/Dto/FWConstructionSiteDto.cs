using SH3H.SDK.Share;
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
    /// 工地
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWConstructionSiteDto
    {
        /// <summary>
        /// 工地编号
        /// </summary>
        [DataMember(Name = "id")]
        public int ID { get; set; }

        /// <summary>
        /// 工地名称
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 工地级别
        /// </summary>
        [DataMember(Name = "level")]
        public int Level { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        [DataMember(Name = "x")]
        public decimal X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        [DataMember(Name = "y")]
        public decimal Y { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 终止日期
        /// </summary>
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 建设单位名称
        /// </summary>
        [DataMember(Name = "constructorName")]
        public string ConstructorName { get; set; }

        /// <summary>
        /// 建设单位负责人
        /// </summary>
        [DataMember(Name = "constructorPic")]
        public string ConstructorPic { get; set; }


        /// <summary>
        /// 建设单位联系电话
        /// </summary>
        [DataMember(Name = "constructorPhone")]
        public string ConstructorPhone { get; set; }

        /// <summary>
        /// 施工单位名称
        /// </summary>
        [DataMember(Name = "builderName")]
        public string BuilderName { get; set; }

        /// <summary>
        /// 施工单位负责人
        /// </summary>
        [DataMember(Name = "builderPic")]
        public string BuilderPic { get; set; }


        /// <summary>
        /// 施工单位联系电话
        /// </summary>
        [DataMember(Name = "builderPhone")]
        public string BuilderPhone { get; set; }

        /// <summary>
        /// 监理单位名称
        /// </summary>
        [DataMember(Name = "supervisorName")]
        public string SupervisorName { get; set; }

        /// <summary>
        /// 监理单位负责人
        /// </summary>
        [DataMember(Name = "supervisorPic")]
        public string SupervisorPic { get; set; }


        /// <summary>
        /// 监理单位联系电话
        /// </summary>
        [DataMember(Name = "supervisorPhone")]
        public string SupervisorPhone { get; set; }

        public static FWConstructionSiteDto FromModel(FWConstructionSite model)
        {
            if (model == null)
            {
                return null;
            }
            FWConstructionSiteDto dto = new FWConstructionSiteDto()
            {
                ID = model.ID,
                Name = model.Name,
                Level = model.Level,
                Address = model.Address,
                X = model.X,
                Y = model.Y,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ConstructorName = model.ConstructorName,
                ConstructorPic = model.ConstructorPic,
                ConstructorPhone = model.ConstructorPhone,
                BuilderName = model.BuilderName,
                BuilderPic = model.BuilderPic,
                BuilderPhone = model.BuilderPhone,
                SupervisorName = model.SupervisorName,
                SupervisorPic = model.SupervisorPic,
                SupervisorPhone = model.SupervisorPhone
            };
            return dto;
        }

        /// <summary>
        /// FWGridDto对象转FWGrid模型
        /// </summary>
        /// <returns></returns>
        public FWConstructionSite ToModel()
        {
            FWConstructionSite model = new FWConstructionSite()
            {
                ID = this.ID,
                Name = this.Name,
                Level = this.Level,
                Address = this.Address,
                X = this.X,
                Y = this.Y,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                ConstructorName = this.ConstructorName,
                ConstructorPic = this.ConstructorPic,
                ConstructorPhone = this.ConstructorPhone,
                BuilderName = this.BuilderName,
                BuilderPic = this.BuilderPic,
                BuilderPhone = this.BuilderPhone,
                SupervisorName = this.SupervisorName,
                SupervisorPic = this.SupervisorPic,
                SupervisorPhone = this.SupervisorPhone
            };

            return model;
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "工地名称不允许为空！");
            }
            if (this.Level <= 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "工地级别不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.Address))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "详细地址不允许为空！");
            }
            if (this.X < Convert.ToDecimal(73.66) || this.X > Convert.ToDecimal(135.05))
            {
                result.AddError(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "X坐标不合法！");
            }
            if (this.Y < Convert.ToDecimal(3.86) || this.Y > Convert.ToDecimal(53.55))
            {
                result.AddError(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "Y坐标不合法！");
            }
            if (null == this.StartDate)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "起始日期不允许为空！");
            }
            return result;
        }
    }
}
