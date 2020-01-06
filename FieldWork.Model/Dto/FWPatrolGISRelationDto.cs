using SH3H.SDK.Share;
using SH3H.WAP.FieldWork.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model.Dto
{
    [Serializable]
    [DataContract(Namespace = SH3H.SDK.Share.Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolGISRelationDto : DtoBase<FWPatrolGISRelation, FWPatrolGISRelationDto>
    {
        /// <summary>
        /// 巡查类型
        /// </summary>
        [DataMember(Name = "patrolType")]
        public int PatrolType { get; set; }

        /// <summary>
        /// GIS图层编号
        /// </summary>
        [DataMember(Name = "gisLayerId")]
        public string GISLayerId { get; set; }

        /// <summary>
        /// GIS图层名称
        /// </summary>
        [DataMember(Name = "gisLayerName")]
        public string GISLayerName { get; set; }

        /// <summary>
        /// 地图服务编号
        /// </summary>
        [DataMember(Name = "mapLayerId")]
        public string MapLayerId { get; set; }

        /// <summary>
        /// 地图服务名称
        /// </summary>
        [DataMember(Name = "mapLayerName")]
        public string MapLayerName { get; set; }

        /// <summary>
        /// JSON格式字符串，用于新增巡查对象从GIS获取属性        /// </summary>
        [DataMember(Name = "fieldMapSchema")]
        public string FieldMapSchema { get; set; }
    }
}
