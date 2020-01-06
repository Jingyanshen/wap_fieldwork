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
    /// 巡查周期Dto
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolObjectDto
    {

        /// <summary>
        /// 编号
        /// </summary>
        [DataMember(Name = "id")]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember(Name = "name")]
        public String Name { get; set; }

        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember(Name = "address")]
        public String Address { get; set; }

        /// <summary>
        /// X坐标(经度)
        /// </summary>
        [DataMember(Name = "x")]
        public Decimal X { get; set; }

        /// <summary>
        /// Y坐标（纬度）
        /// </summary>
        [DataMember(Name = "y")]
        public decimal Y { get; set; }


        /// <summary>
        /// 巡查等级
        /// </summary>
        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        /// <summary>
        /// 所属网格
        /// </summary>
        [DataMember(Name = "gridId")]
        public int GridId { get; set; }

        /// <summary>
        /// 所在道路
        /// </summary>
        [DataMember(Name = "road")]
        public String Road { get; set; }

        /// <summary>
        /// 必达周期
        /// </summary>
        [DataMember(Name = "period")]
        public String Period { get; set; }

        /// <summary>
        /// 必达频次
        /// </summary>
        [DataMember(Name = "frequency")]
        public int Frequency { get; set; }

        /// <summary>
        /// 自定义周期
        /// </summary>
        [DataMember(Name = "periodId")]
        public int PeriodId { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [DataMember(Name = "extend")]
        public String Extend { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember(Name = "creator")]
        public String Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(Name = "createTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// gis图层对象
        /// </summary>
        [DataMember(Name = "gisObjectId")]
        public String GisObjectId { get; set; }

        /// <summary>
        /// gis图层编号
        /// </summary>
        [DataMember(Name = "gisLayerId")]
        public String GisLayerId { get; set; }

        /// <summary>
        /// 地图图层编号
        /// </summary>
        [DataMember(Name = "mapLayerId")]
        public String MapLayerId { get; set; }

        /// <summary>
        /// 便于用户识别的编号
        /// </summary>
        [DataMember(Name = "displayId")]
        public String DisplayId { get; set; }

        /// <summary>
        /// FWPatrolPeriod模型转FWPatrolPeriodDto对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWPatrolObjectDto FromModel(FWPatrolObject model)
        {
            if (model == null)
            {
                return null;
            }
            FWPatrolObjectDto dto = new FWPatrolObjectDto()
            {
                ID = model.ID,
                Name = model.Name,
                PatrolType = model.PatrolType,
                Address = model.Address,
                X = model.X,
                Y = model.Y,
                GridId = model.GridId,
                Road = model.Road,
                Period = model.Period,
                Frequency = model.Frequency,
                PeriodId = model.PeriodId,
                Extend = model.Extend,
                Creator = model.Creator,
                CreateTime = model.CreateTime,
                GisObjectId = model.GisObjectId,
                GisLayerId = model.GisLayerId,
                MapLayerId = model.MapLayerId,
                Grade = model.Grade,
                DisplayId = model.DisplayId
            };
            return dto;
        }

        /// <summary>
        /// FWPatrolPeriodDto对象转FWPatrolPeriod模型
        /// </summary>
        /// <returns></returns>
        public FWPatrolObject ToModel()
        {
            FWPatrolObject model = new FWPatrolObject()
            {
                ID = this.ID,
                Name = this.Name,
                PatrolType = this.PatrolType,
                Address = this.Address,
                X = this.X,
                Y = this.Y,
                GridId = this.GridId,
                Road = this.Road,
                Period = this.Period,
                Frequency = this.Frequency,
                PeriodId = this.PeriodId,
                Extend = this.Extend,
                Creator = this.Creator,
                CreateTime = this.CreateTime,
                GisObjectId = this.GisObjectId,
                GisLayerId = this.GisLayerId,
                MapLayerId = this.MapLayerId,
                Grade = this.Grade,
                DisplayId = this.DisplayId
            };
            return model;
        }

        /// <summary>
        /// 数据验证
        ///中国大致经纬度范围 纬度3.86~53.55，经度73.66~135.05
        /// </summary>
        /// <returns></returns>
        public ValidateResult Validate()
        {
            var result = new ValidateResult();
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查对象名称不允许为空！");
            }
            if (this.PatrolType <= 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查类型不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.Address))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "巡查地址不允许为空！");
            }
            if (this.X < Convert.ToDecimal(73.66) || this.X > Convert.ToDecimal(135.05))
            {
                result.AddError(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "巡查X坐标不合法！");
            }
            if (this.Y < Convert.ToDecimal(3.86) || this.Y > Convert.ToDecimal(53.55))
            {
                result.AddError(StateCode.CODE_ARGUMENT_LIMIT_ERROR, "巡查Y坐标不合法！");
            }
            if (this.GridId <= 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "所属网格不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.Road))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "所在道路不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.Period))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "必达周期不允许为空！");
            }
            if (this.Frequency <= 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "必达频次不允许为空！");
            }

            return result;
        }
    }
}
