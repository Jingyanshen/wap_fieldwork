using SH3H.SDK.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Model
{
    [Serializable]
    [DataContract(Namespace = Consts.NAMESPACE + "/Model/FieldWork")]
    public class FWPatrolGISRelation
    {
        /// <summary>
        /// 巡查类型 
        /// </summary>
        [DataMember]
        public int PatrolType { get; set; }

        /// <summary>
        /// GIS图层编号
        /// </summary>
        [DataMember]
        public string GISLayerId { get; set; }

        /// <summary>
        /// GIS图层名称
        /// </summary>
        [DataMember]
        public string GISLayerName { get; set; }

        /// <summary>
        /// 地图服务编号        /// </summary>
        [DataMember]
        public string MapLayerId { get; set; }

        /// <summary>
        /// 地图服务名称
        /// </summary>
        [DataMember]
        public string MapLayerName { get; set; }

        /// <summary>
        /// JSON格式字符串，用于新增巡查对象从GIS获取属性
        /// </summary>
        public string FieldMapSchema { get; set; }
    }
}
