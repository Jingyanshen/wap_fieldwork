using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.ViewModels
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolObjectViewModel
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
        /// 周期编号
        /// </summary>
        [DataMember(Name = "patrolPeriodId")]
        public int PatrolPeriodId { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        [DataMember(Name = "periodBase")]
        public int PeriodBase { get; set; }

        /// <summary>
        /// 周期间隔
        /// </summary>
        [DataMember(Name = "interval")]
        public int Interval { get; set; }


        /// <summary>
        /// 是否批量选择
        /// </summary>
        [DataMember(Name = "isBatch")]
        public bool IsBatch { get; set; }

        /// <summary>
        /// GISObjectString
        /// </summary>
        [DataMember(Name = "gisObjectString")]
        public string GISObjectString { get; set; }

        /// <summary>
        /// 便于用户识别的编号
        /// </summary>
        [DataMember(Name = "displayId")]
        public string DisplayId { get; set; }

        /// <summary>
        /// 模型转ViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWPatrolObjectViewModel FromModel(FWPatrolObject model)
        {
            if (model == null)
            {
                return null;
            }
            FWPatrolObjectViewModel viewModel = new FWPatrolObjectViewModel()
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
            return viewModel;
        }

        /// <summary>
        /// FWPatrolPeriodViewModel对象转FWPatrolPeriod模型
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
    }
}
