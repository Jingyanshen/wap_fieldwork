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
    /// 网格Dto
    /// </summary>
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWord")]
    public class FWGridDto
    {
        /// <summary>
        /// 网格编号
        /// </summary>
        [DataMember(Name = "id")]
        public int ID { get; set; }

        /// <summary>
        /// 网格名称
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 上级编号
        /// </summary>
        [DataMember(Name = "parentId")]
        public int ParentId { get; set; }

        /// <summary>
        /// 所属组织
        /// </summary>
        [DataMember(Name = "stationId")]
        public int StationId { get; set; }

        /// <summary>
        /// 所属组织名称
        /// </summary>
        [DataMember(Name = "stationName")]
        public string StationName { get; set; }

        /// <summary>
        /// 级别 --用于图层分层展示
        /// </summary>
        [DataMember(Name = "hierarchy")]
        public int Hierarchy { get; set; }

        /// <summary>
        /// gis图层对象
        /// </summary>
        [DataMember(Name = "gisObjectId")]
        public string GisObjectId { get; set; }

        /// <summary>
        /// gis图层编号
        /// </summary>
        [DataMember(Name = "gisLayerId")]
        public string GisLayerId { get; set; }

        /// <summary>
        /// 地图图层编号
        /// </summary>
        [DataMember(Name = "mapLayerId")]
        public string MapLayerId { get; set; }

        /// <summary>
        /// GIS图形
        /// </summary>
        [DataMember(Name = "geometry")]
        public string Geometry { get; set; }

        /// <summary>
        /// 网格范围(矩形)
        /// </summary>
        [DataMember(Name = "extend")]
        public string Extend { get; set; }

        /// <summary>
        /// FWGrid模型转FWGridDto对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static FWGridDto FromModel(FWGrid model)
        {
            if (model == null)
            {
                return null;
            }
            FWGridDto dto = new FWGridDto()
            {
                ID = model.ID,
                Name = model.Name,
                ParentId = model.ParentId,
                StationId = model.StationId,
                StationName = model.StationName,
                Hierarchy = model.Hierarchy,
                GisObjectId = model.GisObjectId,
                GisLayerId = model.GisLayerId,
                MapLayerId = model.MapLayerId,
                Geometry = model.Geometry,
                Extend = model.Extend
            };
            return dto;
        }

        /// <summary>
        /// FWGridDto对象转FWGrid模型
        /// </summary>
        /// <returns></returns>
        public FWGrid ToModel()
        {
            FWGrid model = new FWGrid()
            {
                ID = this.ID,
                Name = this.Name,
                ParentId = this.ParentId,
                StationId = this.StationId,
                StationName = this.StationName,
                Hierarchy = this.Hierarchy,
                GisObjectId = this.GisObjectId,
                GisLayerId = this.GisLayerId,
                MapLayerId = this.MapLayerId,
                Geometry = this.Geometry,
                Extend = this.Extend
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
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "网格名称不允许为空！");
            }
            if (this.ParentId <= 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "上级编号不允许为空！");
            }
            if (this.StationId <= 0)
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "所属组织不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.StationName))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "所属组织名称不允许为空！");
            }
            if (Hierarchy <= 0 )
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "级别不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.GisObjectId))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "gis图层对象不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.GisLayerId))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "gis图层编号不允许为空！");
            }
            if (string.IsNullOrWhiteSpace(this.MapLayerId))
            {
                result.AddError(StateCode.CODE_ARGUMENT_NULL, "地图图层编号不允许为空！");
            }
            return result;
        }
    }
}
